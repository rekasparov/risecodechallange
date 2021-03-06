$(() => {

    var contactNav;
    var reportNav

    var contactView;
    var contactDetailsModal;
    var newContactModal;
    var newContactDetailModal;
    var editContactModal;
    var newReportModal;
    var reportDetailsModal;

    var reportView;

    var pageSizeContact;
    var pageSizeReport;
    var addNewContact;
    var addNewContactDetail;
    var createNewReport;
    var refreshContact;
    var refreshReport;
    var personNameModalTitle;
    var tableContact;
    var tableContactDetail;
    var tableReport;
    var tableReportDetail;

    var formNewContact;
    var txtNameNewContact;
    var txtSurnameNewContact;
    var txtCompanyNewContact;
    var txtPhoneNumberNewContact;
    var txtEmailAddressNewContact;
    var txtLocationNewContact;
    var btnSaveNewContact;

    var formEditContact;
    var txtNameEditContact;
    var txtSurnameEditContact;
    var txtCompanyEditContact;
    var btnSaveEditContact;

    var formNewContactDetail;
    var txtPersonIdContactDetail;
    var txtPhoneNumberNewContactDetail;
    var txtEmailAddressNewContactDetail;
    var txtLocationNewContactDetail;
    var btnSaveNewContactDetail;

    var txtReportIdContactDetail;

    $(document).ready(() => {
        init();
    });

    init = () => {
        contactNav = $('#contactNav');
        $(contactNav).on('click', contactNav_click);

        reportNav = $('#reportNav');
        $(reportNav).on('click', reportNav_click);

        contactView = $('#contactView');
        reportView = $('#reportView');

        contactDetailsModal = $('#contactDetailsModal');
        newContactModal = $('#newContactModal');
        newContactDetailModal = $('#newContactDetailModal');
        editContactModal = $('#editContactModal');
        newReportModal = $('#newReportModal');
        reportDetailsModal = $('#reportDetailsModal');

        pageSizeContact = $('#pageSizeContact');
        $(pageSizeContact).on('change', pageSizeContact_change);

        pageSizeReport = $('#pageSizeReport');
        $(pageSizeReport).on('change', pageSizeReport_change);

        addNewContact = $('#addNewContact');
        $(addNewContact).on('click', addNewContact_click);

        addNewContactDetail = $('#addNewContactDetail');
        $(addNewContactDetail).on('click', addNewContactDetail_click);

        createNewReport = $('#createNewReport');
        $(createNewReport).on('click', createNewReport_click);

        refreshContact = $('#refreshContact');
        $(refreshContact).on('click', refreshContact_click);

        refreshReport = $('#refreshReport');
        $(refreshReport).on('click', refreshReport_click);

        personNameModalTitle = $('#personNameModalTitle');
        tableContact = $('#tableContact');
        tableContactDetail = $('#tableContactDetail');
        tableReport = $('#tableReport');
        tableReportDetail = $('#tableReportDetail');

        formNewContact = $('#formNewContact');
        $(formNewContact).validate({
            rules: {
                'txtNameNewContact': 'required',
                'txtSurnameNewContact': 'required',
                'txtCompanyNewContact': 'required',
                'txtPhoneNumberNewContact': 'required',
                'txtEmailAddressNewContact': 'required',
                'txtLocationNewContact': 'required'
            }
        });
        txtNameNewContact = $('#txtNameNewContact');
        txtSurnameNewContact = $('#txtSurnameNewContact');
        txtCompanyNewContact = $('#txtCompanyNewContact');
        txtPhoneNumberNewContact = $('#txtPhoneNumberNewContact');
        txtEmailAddressNewContact = $('#txtEmailAddressNewContact');
        txtLocationNewContact = $('#txtLocationNewContact');
        btnSaveNewContact = $('#btnSaveNewContact');
        $(btnSaveNewContact).on('click', btnSaveNewContact_click);

        formEditContact = $('#formEditContact');
        $(formEditContact).validate({
            rules: {
                'txtNameEditContact': 'required',
                'txtSurnameEditContact': 'required',
                'txtCompanyEditContact': 'required'
            }
        });
        txtUUIDEditContact = $('#txtUUIDEditContact');
        txtNameEditContact = $('#txtNameEditContact');
        txtSurnameEditContact = $('#txtSurnameEditContact');
        txtCompanyEditContact = $('#txtCompanyEditContact');
        btnSaveEditContact = $('#btnSaveEditContact');
        $(btnSaveEditContact).on('click', btnSaveEditContact_click);

        formNewContactDetail = $('#formNewContactDetail');
        $(formEditContact).validate({
            rules: {
                'txtPhoneNumberNewContactDetail': 'required',
                'txtEmailAddressNewContactDetail': 'required',
                'txtLocationNewContactDetail': 'required'
            }
        });
        txtPersonIdContactDetail = $('#txtPersonIdContactDetail');
        txtPhoneNumberNewContactDetail = $('#txtPhoneNumberNewContactDetail');
        txtEmailAddressNewContactDetail = $('#txtEmailAddressNewContactDetail');
        txtLocationNewContactDetail = $('#txtLocationNewContactDetail');
        btnSaveNewContactDetail = $('#btnSaveNewContactDetail');
        $(btnSaveNewContactDetail).on('click', btnSaveNewContactDetail_click);

        txtReportIdContactDetail = $('#txtReportIdContactDetail');

        getContacts();
        getReports();
    };

    contactNav_click = () => {
        if ($(contactView).hasClass('d-none')) $(contactView).removeClass('d-none');
        if (!$(reportView).hasClass('d-none')) $(reportView).addClass('d-none');

        if ($(reportNav).parent().hasClass('active')) $(reportNav).parent().removeClass('active');
        if (!$(contactNav).parent().hasClass('active')) $(contactNav).parent().addClass('active');
    };

    reportNav_click = () => {
        if ($(reportView).hasClass('d-none')) $(reportView).removeClass('d-none');
        if (!$(contactView).hasClass('d-none')) $(contactView).addClass('d-none');

        if ($(contactNav).parent().hasClass('active')) $(contactNav).parent().removeClass('active');
        if (!$(reportNav).parent().hasClass('active')) $(reportNav).parent().addClass('active');
    };

    pageSizeContact_change = () => {
        getContacts();
    };

    pageSizeReport_change = () => {
        getReports();
    };

    btnSaveNewContactDetail_click = () => {
        if ($(formNewContactDetail).valid()) addContactDetail();
    };

    btnSaveNewContact_click = () => {
        if ($(formNewContact).valid()) addContact();
    };

    btnSaveEditContact_click = () => {
        if ($(formEditContact).valid()) editContact();
    };

    addNewContact_click = () => {
        clearNewContactForm();
        $(newContactModal).modal('show');
    };

    addNewContactDetail_click = () => {
        clearNewContactDetailForm();
        $(newContactDetailModal).modal('show');
    };

    createNewReport_click = () => {
        createReport();
    };

    refreshContact_click = () => {
        getContacts();
    };

    refreshReport_click = () => {
        getReports();
    };

    clearNewContactForm = () => {
        $(txtNameNewContact).val('');
        $(txtSurnameNewContact).val('');
        $(txtCompanyNewContact).val('');
        $(txtPhoneNumberNewContact).val('');
        $(txtEmailAddressNewContact).val('');
        getCurrentLocationForNewContact();
    };

    clearNewContactDetailForm = () => {
        $(txtPhoneNumberNewContactDetail).val('');
        $(txtEmailAddressNewContactDetail).val('');
        getCurrentLocationForNewContactDetail();
    };

    getCurrentLocationForNewContact = () => {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition((x) => {
                var latitude = x.coords.latitude;
                var longitude = x.coords.longitude;
                var location = latitude + ',' + longitude;
                $(txtLocationNewContact).val(location);
            });
        }
    };

    getCurrentLocationForNewContactDetail = () => {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition((x) => {
                var latitude = x.coords.latitude;
                var longitude = x.coords.longitude;
                var location = latitude + ',' + longitude;
                $(txtLocationNewContactDetail).val(location);
            });
        }
    };

    createReport = () => {
        var url = 'http://localhost:8004/api/Report/CreateReport';

        ajaxRequest(url, 'POST', true, null,
            null,
            (x, y, z) => {
                if (x.HasError) {
                    debugger;
                }
                else {
                    getReports();
                }
            },
            (x, y) => {
                debugger;
            }, () => {
                $(newReportModal).modal('show');
            });
    };

    editContact = () => {
        var url = 'http://localhost:8000/api/Person/EditPerson';
        var data = {
            UUID: $(txtUUIDEditContact).val(),
            Name: $(txtNameEditContact).val(),
            Surname: $(txtSurnameEditContact).val(),
            Company: $(txtCompanyEditContact).val()
        };
        var jsonData = JSON.stringify(data);

        ajaxRequest(url, 'PUT', true, jsonData,
            null,
            (x, y, z) => {
                if (x.HasError) {
                    debugger;
                }
                else {
                    getContacts();
                }
            },
            (x, y) => {
                debugger;
            },
            () => {
                $(editContactModal).modal('hide');
            });
    };

    addContactDetail = () => {
        var personId = $(txtPersonIdContactDetail).val();
        var url = 'http://localhost:8002/api/PersonContact/CreateNewPersonContact';
        var data = {
            PersonId: personId,
            PhoneNumber: $(txtPhoneNumberNewContactDetail).val(),
            EmailAddress: $(txtEmailAddressNewContactDetail).val(),
            Location: $(txtLocationNewContactDetail).val()
        };
        var jsonData = JSON.stringify(data);

        ajaxRequest(url, 'POST', true, jsonData,
            null,
            (x, y, z) => {
                if (x.HasError) {
                    debugger;
                }
                else {
                    getPersonContacts(personId);
                }
            },
            (x, y) => {
                debugger;
            }, () => {
                $(newContactDetailModal).modal('hide');
            });
    };

    addContact = () => {
        var url = 'http://localhost:8000/api/Person/CreateNewPerson';
        var data = {
            Person: {
                Name: $(txtNameNewContact).val(),
                Surname: $(txtSurnameNewContact).val(),
                Company: $(txtCompanyNewContact).val()
            },
            PersonContacts: [
                {
                    PhoneNumber: $(txtPhoneNumberNewContact).val(),
                    EmailAddress: $(txtEmailAddressNewContact).val(),
                    Location: $(txtLocationNewContact).val()
                }
            ]
        };
        var jsonData = JSON.stringify(data);

        ajaxRequest(url, 'POST', true, jsonData,
            null,
            (x, y, z) => {
                if (x.HasError) {
                    debugger;
                }
                else {
                    getContacts();
                }
            },
            (x, y) => {
                debugger;
            },
            () => {
                $(newContactModal).modal('hide');
            });
    };

    deleteContact = (uuid) => {
        var url = 'http://localhost:8000/api/Person/DeletePerson';
        var data = {
            UUID: uuid
        };
        var jsonData = JSON.stringify(data);

        ajaxRequest(url, 'DELETE', true, jsonData,
            null,
            (x, y, z) => {
                if (x.HasError) {
                    debugger;
                }
                else {
                    getContacts();
                }
            },
            (x, y) => {
                debugger;
            },
            null);
    };

    deleteContactDetail = (uuid) => {
        var personId = $(txtPersonIdContactDetail).val();
        var url = 'http://localhost:8002/api/PersonContact/DeletePersonContact';
        var data = {
            UUID: uuid
        };
        var jsonData = JSON.stringify(data);

        ajaxRequest(url, 'DELETE', true, jsonData,
            null,
            (x, y, z) => {
                if (x.HasError) {
                    debugger;
                }
                else {
                    getPersonContacts(personId);
                }
            },
            (x, y) => {
                debugger;
            },
            null);
    };

    getContact = (uuid) => {
        var baseUrl = 'http://localhost:8000/api/Person/GetPersonByUUID';
        var parameters = '?uuid=' + uuid;
        var url = baseUrl + parameters;

        ajaxRequest(url, 'GET', true, null,
            null,
            (x, y, z) => {
                if (x.HasError) {
                    debugger;
                }
                else {
                    bindContact(x.Data);
                }
            },
            (x, y) => {
                debugger;
            },
            null);
    };

    getContacts = () => {
        var pageSize = $(pageSizeContact).val();
        var pageIndex = 0;

        var baseUrl = 'http://localhost:8000/api/Person/GetPersonList';
        var parameters = '?pageIndex=' + pageIndex + '&pageSize=' + pageSize;
        var url = baseUrl + parameters;

        ajaxRequest(url, 'GET', true, null,
            null,
            (x, y, z) => {
                if (x.HasError) {
                    debugger;
                }
                else {
                    bindContacts(x.Data);
                }
            },
            (x, y) => {
                debugger;
            },
            null);
    };

    getReports = () => {
        var pageSize = $(pageSizeReport).val();
        var pageIndex = 0;

        var baseUrl = 'http://localhost:8004/api/Report/GetReportList';
        var parameters = '?pageIndex=' + pageIndex + '&pageSize=' + pageSize;
        var url = baseUrl + parameters;

        ajaxRequest(url, 'GET', true, null,
            null,
            (x, y, z) => {
                if (x.HasError) {
                    debugger;
                }
                else {
                    bindReports(x.Data);
                }
            },
            (x, y) => {
                debugger;
            },
            null);
    };

    getPersonContacts = (personId) => {
        var baseUrl = 'http://localhost:8002/api/PersonContact/GetPersonContactsByPersonId';
        var parameters = '?personId=' + personId;
        var url = baseUrl + parameters;

        ajaxRequest(url, 'GET', true, null,
            null,
            (x, y, z) => {
                if (x.HasError) {
                    debugger;
                }
                else {
                    bindPersonContacts(x.Data);
                }
            },
            (x, y) => {
                debugger;
            }, null);
    };

    getReportDetails = (reportId) => {
        var baseUrl = 'http://localhost:8006/api/ReportDetail/GetReportDetailsByReportId';
        var parameters = '?reportId=' + reportId;
        var url = baseUrl + parameters;

        ajaxRequest(url, 'GET', true, null,
            null,
            (x, y, z) => {
                if (x.HasError) {
                    debugger;
                }
                else {
                    bindReportDetails(x.Data);
                }
            },
            (x, y) => {
                debugger;
            }, null);
    };

    showPersonDetailModal = (x) => {
        $(txtPersonIdContactDetail).val(x);
        $(contactDetailsModal).modal('show');
    };

    showReportDetailModal = () => {
        $(reportDetailsModal).modal('show');
    };

    bindContact = (data) => {
        var uuid = data.UUID;
        var name = data.Name;
        var surname = data.Surname;
        var company = data.Company;
        $(txtUUIDEditContact).val(uuid);
        $(txtNameEditContact).val(name);
        $(txtSurnameEditContact).val(surname);
        $(txtCompanyEditContact).val(company);
        $(editContactModal).modal('show');
    };

    bindContacts = (data) => {
        var innerHtml = '';
        for (var index = 0; index < data.length; index++) {
            var uuid = data[index].UUID;
            var name = data[index].Name;
            var surname = data[index].Surname;
            var company = data[index].Company;
            innerHtml += '<tr>';
            innerHtml += '<td class="d-none">' + uuid + '</td>';
            innerHtml += '<td class="text-left w-25">' + name + '</td>';
            innerHtml += '<td class="text-left w-25">' + surname + '</td>';
            innerHtml += '<td class="text-left w-25">' + company + '</td>';
            innerHtml += '<td class="text-center w-25">';
            innerHtml += '<button class="btn btn-sm btn-outline-primary mr-2" onclick="showContactDetails(this)" data-id="' + uuid + '"><i class="fa fa-eye text-dark"></i></button>';
            innerHtml += '<button class="btn btn-sm btn-outline-warning mr-2" onclick="showContactForEdit(this)" data-id="' + uuid + '"><i class="fa fa-pen text-dark"></i></button>';
            innerHtml += '<button class="btn btn-sm btn-outline-danger mr-2" onclick="deleteContacts(this)" data-id="' + uuid + '"><i class="fa fa-eraser text-dark"></i></button>';
            innerHtml += '</td>';
            innerHtml += '/<tr>';
        }
        $(tableContact).html(innerHtml);
    };

    bindReports = (data) => {
        var innerHtml = '';
        for (var index = 0; index < data.length; index++) {
            var uuid = data[index].UUID;
            var requestDate = data[index].RequestDate;
            var status = data[index].Status;
            var statusStr = status == true ? 'Rapor Hazırlandı' : 'Hazırlanıyor';
            var textColor = status == true ? 'text-primary' : 'text-secondary';
            innerHtml += '<tr>';
            innerHtml += '<td class="d-none">' + uuid + '</td>';
            innerHtml += '<td class="text-left w-25">' + requestDate + '</td>';
            innerHtml += '<td class="text-left w-50 ' + textColor + '">' + statusStr + '</td>';
            innerHtml += '<td class="text-center w-25">';
            if (status === true) {
                innerHtml += '<button class="btn btn-sm btn-outline-primary mr-2" onclick="showReportDetails(this)" data-id="' + uuid + '"><i class="fa fa-eye text-dark"></i></button>';
            }
            else {
                innerHtml += '<button class="btn btn-sm btn-outline-primary mr-2 disabled" disabled><i class="fa fa-eye text-dark"></i></button>';
            }
            innerHtml += '</td>';
            innerHtml += '</tr>';
        }
        $(tableReport).html(innerHtml);
    };

    bindPersonContacts = (data) => {
        var innerHtml = '';
        var personName = '';
        for (var index = 0; index < data.length; index++) {
            var uuid = data[index].UUID;
            var personId = data[index].PersonId;
            var phoneNumber = data[index].PhoneNumber;
            var emailAddress = data[index].EmailAddress;
            var location = data[index].Location;
            if (personName == '') personName = (data[index].Person.Name + ' ' + data[index].Person.Surname);
            innerHtml += '<tr>';
            innerHtml += '<td class="d-none">' + uuid + '</td>';
            innerHtml += '<td class="d-none">' + personId + '</td>';
            innerHtml += '<td class="text-left w-25">' + phoneNumber + '</td>';
            innerHtml += '<td class="text-left w-25">' + emailAddress + '</td>';
            innerHtml += '<td class="text-left w-25">' + location + '</td>';
            innerHtml += '<td class="text-center w-25">';
            innerHtml += '<button class="btn btn-sm btn-outline-danger mr-2" onclick="deleteContactDetails(this)" data-id="' + uuid + '"><i class="fa fa-eraser text-dark"></i></button>';
            innerHtml += '</td>';
            innerHtml += '/<tr>';
        }
        $(tableContactDetail).html(innerHtml);
        $(personNameModalTitle).html(personName);
    };

    bindReportDetails = (data) => {
        var innerHtml = '';
        for (var index = 0; index < data.length; index++) {
            var uuid = data[index].UUID;
            var reportId = data[index].ReportId;
            var location = data[index].Location;
            var personCount = data[index].PersonCount;
            var phoneNumberCount = data[index].PhoneNumberCount;
            innerHtml += '<tr>';
            innerHtml += '<td class="d-none">' + uuid + '</td>';
            innerHtml += '<td class="d-none">' + reportId + '</td>';
            innerHtml += '<td class="text-left w-50">' + location + '</td>';
            innerHtml += '<td class="text-left w-25">' + personCount + '</td>';
            innerHtml += '<td class="text-left w-25">' + phoneNumberCount + '</td>';
            innerHtml += '</td>';
            innerHtml += '/<tr>';
        }
        $(tableReportDetail).html(innerHtml);
    };

    showContactDetails = (e) => {
        var personId = $(e).data('id');
        getPersonContacts(personId);
        showPersonDetailModal(personId);
    };

    showReportDetails = (e) => {
        var reportId = $(e).data('id');
        getReportDetails(reportId);
        showReportDetailModal(reportId);
    };

    showContactForEdit = (e) => {
        var uuid = $(e).data('id');
        getContact(uuid);
    };

    deleteContacts = (e) => {
        var uuid = $(e).data('id');
        if (confirm('Kaydı silmek istediğinizden emin misiniz?')) deleteContact(uuid);
    };

    deleteContactDetails = (e) => {
        var uuid = $(e).data('id');
        if (confirm('Kaydı silmek istediğinizden emin misiniz?')) deleteContactDetail(uuid);
    };

    ajaxRequest = (url, method, async, data, beforeSend, success, error, complete) => {
        $.ajax({
            url: url,
            method: method,
            async: async,
            data: data,
            beforeSend: beforeSend,
            success: success,
            error: error,
            complete: complete,
            contentType: 'application/json'
        });
    };
});