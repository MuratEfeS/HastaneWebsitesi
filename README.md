[Hastane Website Projesi]

Bu proje, ASP.NET Core MVC teknolojisi ile geliştirilmiş, hastane, poliklinik ve doktor verilerinin yönetilebildiği veritabanı tabanlı bir web uygulamasıdır. İlişkisel veritabanı (SQL) yapısı üzerine kurulan sistemde 4 farklı tablo için veri giriş-çıkışı (CRUD), görsel yükleme işlemleri ve ViewModel yapıları  html css kullanılarak website haline getirilmiştir. Proje, temiz kod (Clean-Code) standartlarına vuygun olarak tamamlanmıştır.
  
## 🛠 Kullanılan Teknolojiler

* **Backend:** ASP.NET Core MVC, C#
* **ORM:** Entity Framework Core (Code First)
* **Veritabanı:**  SQL
* **Frontend:** HTML5, CSS3, JavaScript, Bootstrap 

---

## 📋 Proje Özellikleri ve Gereksinimlerin Karşılanması

Bu proje, ders kapsamında belirtilen aşağıdaki kriterleri eksiksiz sağlamaktadır:

1.  **CRUD İşlemleri:** Tüm varlıklar (Hastaneler, Poliklinikler, Doktorlar vb.) üzerinde Ekleme, Silme, Güncelleme ve Listeleme işlemleri yapılabilmektedir.
2.  **ViewModel Kullanımı:** Veri taşıma işlemleri ve form yapılarında `ViewModel` tasarım deseni kullanılarak (en az 2 yerde) bağımlılıklar yönetilmiştir.
3.  **Dropdown (Select-Option) Yapısı:** İlişkisel veriler (örneğin doktor eklerken poliklinik seçimi) kullanıcıya dinamik dropdown listeleri ile sunulmaktadır.
4.  **Görsel Yükleme:** Sisteme doktor veya hastane görseli yüklenebilmekte ve `wwwroot` klasöründe saklanmaktadır.
5.  **Arayüz:** Görsel açıdan derli toplu, kullanıcı dostu ve responsive bir tasarım uygulanmıştır.
---
## 🗄 Veritabanı Yapısı (4 Tablo)

Proje aşağıdaki temel varlıklar (Entities) üzerine kuruludur:

1.  **Hastaneler** (Hastanenin genel bilgileri)
2.  **Poliklinikler** (Hastaneye bağlı birimler)
3.  **Doktorlar** - Görsel İçerir.
4.  **Randevular/Hastalar** - - Görsel İçerir.
