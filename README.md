# RISE code challange
RISE Code challange uygulamas�n� ta��yan repositorydir.
# AMA�
Yap�lmak istenen bir rehber uygulamas� ve buna ba�l� baz� raporlar�n �retilmesidir.
Yeni kay�tlar�n girilebilce�i, mevcut kay�tlar�n d�zenlenebilece�i, silinebilece�i ve detaylar�n g�r�nt�lenebilece�i;
Ayr�ca konum bazl� baz� raporlar�n haz�rlanaca�� bir web uygulamas� geli�tirilmi�tir.
# Rehber
Rehber sekmesinde kullan�c� daha �nceden olu�turulmu� kay�tlar� listeleyebilir, yeni kay�t ekleyebilir, d�zenleyebilir ve silebilir.
Her bir kayd�n detay butonuna bas�lma suretiyle ki�iye ait birden fazla bilginin g�r�nt�lendi�i form �zerinden kay�tlar g�r�nt�lenebilir,
silinebilir ve/veya yeni kay�t eklenebilir.
# Rapor
Rapor sayfas�nda kullan�c� yeni bir rapor talebinde bulunabilir. Rapor olu�ma s�resi kay�tlar�n miktar�na g�re de�i�iklik g�sterebilir.
Yeni bir rapor talebi yap�ld���nda Rapor sayfas� yenilenmek suretiyle olu�turulan raporun haz�r olup olmad��� g�r�nt�lenir.
Haz�r olan raporlar�n detay butonuna bas�larak detaylar g�r�nt�lenebilir.
# Gereksinimler
Uygulaman�n do�ru �al��mas� i�in 1920x1080 ��z�n�rl���ne sahip olunmas� tavsiye edilir.
Uygulaman�n h�z� kullan�c�n�n internet h�z� ile do�rudan etkilidir.
# Sistem gereksinimleri
Uygulaman�n API uygulamas� .Net Core 5.0 teknolojisi ile geli�tirilmi�tir.
API uygulamas� herhangi bir .Net Core 5.0 y�kl� i�letim sisteminde �al��abilir. (Windows, Linux, MacOS vb.)
Web Uygulamas� .Net 5.0 ile geli�tirilmi� bir IIS uygulamas�d�r. Windows �zerinde IIS ile di�er platformalarda ise Kerstel yap�s�nda yay�na al�nabilir.
Veritaban� PostgreSQL 14 versiyonu olarak kullan�lm��t�r.
Mesaj kuyruk yap�s� RabbitMQ ve MassTransit ile desteklenmektedir.
Uygulama Microservice mimarisine uygun da��t�k mimari uygulanarak DDD(Domain Driven Design) tasar�m�na uygun geli�tirilmi�tir.
Connectionstring de�eri Entity kayman� i�erisindeki DbContext nesnesinin parametresi olarak belirlenmi� de�i�tirilmek istendi�inde hedef adresteki de�erin de�i�tirilmesi gerekmektedir.
# Geli�tirici Bilgisi
Geli�tirici: Mustafa Burak Kayabal
�nvan�: Senior Software Developer
Uygulama versiyonu: Versiyon 1.0
Aktif G�T Geli�tirme Branch�: development
Aktif G�T Production Branch�: master
Son g�ncellenme tarihi: 27.10.2021 13:41
