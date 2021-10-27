# RISE code challange
RISE Code challange uygulamasýný taþýyan repositorydir.
# AMAÇ
Yapýlmak istenen bir rehber uygulamasý ve buna baðlý bazý raporlarýn üretilmesidir.
Yeni kayýtlarýn girilebilceði, mevcut kayýtlarýn düzenlenebileceði, silinebileceði ve detaylarýn görüntülenebileceði;
Ayrýca konum bazlý bazý raporlarýn hazýrlanacaðý bir web uygulamasý geliþtirilmiþtir.
# Rehber
Rehber sekmesinde kullanýcý daha önceden oluþturulmuþ kayýtlarý listeleyebilir, yeni kayýt ekleyebilir, düzenleyebilir ve silebilir.
Her bir kaydýn detay butonuna basýlma suretiyle kiþiye ait birden fazla bilginin görüntülendiði form üzerinden kayýtlar görüntülenebilir,
silinebilir ve/veya yeni kayýt eklenebilir.
# Rapor
Rapor sayfasýnda kullanýcý yeni bir rapor talebinde bulunabilir. Rapor oluþma süresi kayýtlarýn miktarýna göre deðiþiklik gösterebilir.
Yeni bir rapor talebi yapýldýðýnda Rapor sayfasý yenilenmek suretiyle oluþturulan raporun hazýr olup olmadýðý görüntülenir.
Hazýr olan raporlarýn detay butonuna basýlarak detaylar görüntülenebilir.
# Gereksinimler
Uygulamanýn doðru çalýþmasý için 1920x1080 çözünürlüðüne sahip olunmasý tavsiye edilir.
Uygulamanýn hýzý kullanýcýnýn internet hýzý ile doðrudan etkilidir.
# Sistem gereksinimleri
Uygulamanýn API uygulamasý .Net Core 5.0 teknolojisi ile geliþtirilmiþtir.
API uygulamasý herhangi bir .Net Core 5.0 yüklü iþletim sisteminde çalýþabilir. (Windows, Linux, MacOS vb.)
Web Uygulamasý .Net 5.0 ile geliþtirilmiþ bir IIS uygulamasýdýr. Windows üzerinde IIS ile diðer platformalarda ise Kerstel yapýsýnda yayýna alýnabilir.
Veritabaný PostgreSQL 14 versiyonu olarak kullanýlmýþtýr.
Mesaj kuyruk yapýsý RabbitMQ ve MassTransit ile desteklenmektedir.
Uygulama Microservice mimarisine uygun daðýtýk mimari uygulanarak DDD(Domain Driven Design) tasarýmýna uygun geliþtirilmiþtir.
Connectionstring deðeri Entity kaymaný içerisindeki DbContext nesnesinin parametresi olarak belirlenmiþ deðiþtirilmek istendiðinde hedef adresteki deðerin deðiþtirilmesi gerekmektedir.
# Geliþtirici Bilgisi
Geliþtirici: Mustafa Burak Kayabal
Ünvaný: Senior Software Developer
Uygulama versiyonu: Versiyon 1.0
Aktif GÝT Geliþtirme Branchý: development
Aktif GÝT Production Branchý: master
Son güncellenme tarihi: 27.10.2021 13:41
