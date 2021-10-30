using MassTransit;
using Newtonsoft.Json;
using RISE.BusinessLayer.Abstract;
using RISE.DataTransferObject;
using RISE.Shared.Events;
using RISE.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RISE.ReportDetailApi.Consumers
{
    public class ReportCreatedConsumer : IConsumer<ReportCreatedEvent>
    {
        private readonly IReportDetailBl reportDetailBl;
        private readonly ISendEndpointProvider sendEndpointProvider;

        public ReportCreatedConsumer(IReportDetailBl reportDetailBl, ISendEndpointProvider sendEndpointProvider)
        {
            this.reportDetailBl = reportDetailBl;
            this.sendEndpointProvider = sendEndpointProvider;
        }

        public async Task Consume(ConsumeContext<ReportCreatedEvent> context)
        {
            try
            {
                List<ReportDetailDto> reportDetails = new List<ReportDetailDto>();

                List<string> locationList = await getLocationList();

                foreach (var location in locationList)
                {
                    int personCount = await getPersonCountByLocation(location);
                    int phoneNumberCount = await getPhoneNumberCountByLocation(location);
                    reportDetails.Add(new ReportDetailDto()
                    {
                        UUID = Guid.NewGuid(),
                        ReportId = context.Message.ReportCreatedMessage.ReportId,
                        Location = location,
                        PersonCount = personCount,
                        PhoneNumberCount = phoneNumberCount
                    });
                }

                await reportDetailBl.CreateReport(reportDetails);

                ReportDetailCreatedEvent reportDetailCreatedEvent = new ReportDetailCreatedEvent()
                {
                    ReportDetailCreatedMessage = new ReportDetailCreatedEvent.ReportDetailCreatedMessageModel()
                    {
                        ReportId = context.Message.ReportCreatedMessage.ReportId
                    }
                };

                ISendEndpoint sendEndpoint = await sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{RabbitMQSettingsModel.ReportDetailCreatedQueueName}"));

                await sendEndpoint.Send(reportDetailCreatedEvent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error={ex.Message}");

                ReportDetailNotCreatedEvent reportDetailNotCreatedEvent = new ReportDetailNotCreatedEvent()
                {
                    ReportDetailNotCreatedMessage = new ReportDetailNotCreatedEvent.ReportDetailNotCreatedMessageModel()
                    {
                        UUID = context.Message.ReportCreatedMessage.ReportId
                    }
                };

                ISendEndpoint sendEndpoint = await sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{RabbitMQSettingsModel.ReportDetailNotCreatedQueueName}"));

                await sendEndpoint.Send(reportDetailNotCreatedEvent);
            }
        }

        private async Task<List<string>> getLocationList()
        {
            try
            {
                HttpClient httpClient = new HttpClient();

                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("http://localhost:8002/api/PersonContact/GetLocationList")
                };

                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                string jsonData = await httpResponseMessage.Content.ReadAsStringAsync();

                ResponseDataModel responseData = JsonConvert.DeserializeObject<ResponseDataModel>(jsonData);

                if (responseData.HasError) throw new Exception();

                return JsonConvert.DeserializeObject<List<string>>(responseData.Data.ToString());
            }
            catch
            {
                throw;
            }
        }

        private async Task<int> getPersonCountByLocation(string location)
        {
            try
            {
                HttpClient httpClient = new HttpClient();

                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"http://localhost:8002/api/PersonContact/GetPersonCountByLocation?location={location}")
                };

                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                string jsonData = await httpResponseMessage.Content.ReadAsStringAsync();

                ResponseDataModel responseData = JsonConvert.DeserializeObject<ResponseDataModel>(jsonData);

                if (responseData.HasError) throw new Exception();

                return int.Parse(responseData.Data.ToString());
            }
            catch
            {
                throw;
            }
        }

        private async Task<int> getPhoneNumberCountByLocation(string location)
        {
            try
            {
                HttpClient httpClient = new HttpClient();

                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"http://localhost:8002/api/PersonContact/GetPhoneNumberCountByLocation?location={location}")
                };

                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                string jsonData = await httpResponseMessage.Content.ReadAsStringAsync();

                ResponseDataModel responseData = JsonConvert.DeserializeObject<ResponseDataModel>(jsonData);

                if (responseData.HasError) throw new Exception();

                return int.Parse(responseData.Data.ToString());
            }
            catch
            {
                throw;
            }
        }
    }
}
