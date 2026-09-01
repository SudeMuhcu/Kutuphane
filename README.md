# 📚 Kütüphane Yönetim Sistemi

Bu proje, öğrencilerin kitap ödünç alma ve iade işlemlerini yönetmek amacıyla geliştirilmiş bir **Kütüphane Yönetim Sistemi** uygulamasıdır.

Proje, **ASP.NET Core MVC** mimarisi kullanılarak geliştirilmiş olup; öğrenci, kitap ve ödünç işlemlerinin yönetilmesini sağlar.

## 🚀 Projenin Özellikleri

* 👤 Öğrenci kayıt ve listeleme
* 📚 Kitap ekleme, listeleme ve yönetme
* 🔄 Kitap ödünç alma ve iade işlemleri
* 📦 Kitap stok takibi
* 🔐 Kullanıcı giriş sistemi
* 👑 Admin ve öğrenci rolleri
* 🛡️ Role göre yetkilendirme
* 🔑 Authentication ve Authorization
* 📋 Ödünç alınan kitapların takibi
* 🔎 Öğrenci ve ödünç kayıtlarında arama
* ⚠️ İade edilmemiş kitapların kontrolü
* 🗄️ Entity Framework Core ile veritabanı işlemleri

## 🛠️ Kullanılan Teknolojiler

* **C#**
* **ASP.NET Core MVC**
* **Entity Framework Core**
* **SQL Server**
* **Razor View**
* **Dependency Injection**
* **Repository Pattern**
* **Service Layer**
* **Authentication & Authorization**
* **Claims**
* **BCrypt**

## 🏗️ Proje Yapısı

```text
Kutuphane
│
├── Controllers
│   ├── LoginController
│   ├── StudentController
│   ├── BookController
│   └── LoanController
│
├── Models
│   ├── Student
│   ├── Book
│   ├── Loan
│   └── AppUser
│
├── Services
│   ├── StudentService
│   ├── BookService
│   └── LoanService
│
├── Repositories
│
├── Views
│
├── Data
│   └── LibraryContext
│
└── wwwroot
```

## 👥 Kullanıcı Rolleri

### 👑 Admin

Admin kullanıcılar;

* Öğrencileri görüntüleyebilir ve yönetebilir.
* Kitapları yönetebilir.
* Ödünç işlemlerini görüntüleyebilir.
* Kitap iade işlemlerini takip edebilir.

### 👨‍🎓 Öğrenci

Öğrenciler;

* Kitapları görüntüleyebilir.
* Kitap ödünç alma işlemi gerçekleştirebilir.
* Kendi ödünç aldığı kitapları takip edebilir.
* İade durumlarını görüntüleyebilir.

## 🔐 Güvenlik

Projede kullanıcıların sisteme giriş yapabilmesi için Authentication mekanizması kullanılmaktadır.

Kullanıcıların yetkileri **Role** ve **Claims** üzerinden kontrol edilmektedir. Şifrelerin veritabanında güvenli şekilde tutulması için **BCrypt** kullanılmıştır.

## 🗄️ Veritabanı

Proje **SQL Server** ve **Entity Framework Core** kullanmaktadır.

Temel tablolar:

* `Students`
* `Books`
* `Loans`
* `AppUsers`

Öğrenci ve kitap arasındaki ödünç ilişkileri `Loan` tablosu üzerinden takip edilmektedir.

## ⚙️ Kurulum

Projeyi bilgisayarınıza klonladıktan sonra:

```bash
git clone PROJE_LINKIN
```

Projeyi **Visual Studio** ile açın.

Daha sonra `appsettings.json` içerisindeki SQL Server bağlantı adresini kendi bilgisayarınıza göre düzenleyin.

Veritabanını oluşturmak/güncellemek için Entity Framework Core Migration işlemlerini kullanabilirsiniz:

```bash
Update-Database
```

Ardından projeyi çalıştırabilirsiniz.

## 📌 Proje Amacı

Bu proje, **ASP.NET Core MVC, Entity Framework Core, SQL Server, Repository Pattern, Service Layer, Authentication ve Authorization** gibi web geliştirme konularında pratik yapmak amacıyla geliştirilmiştir.

Aynı zamanda gerçek bir kütüphane sisteminde bulunabilecek temel kitap, öğrenci ve ödünç yönetimi işlemlerini uygulamalı olarak ele almaktadır.

## 👩‍💻 Geliştirici

**Sude Muhçu**

Bu proje eğitim ve geliştirme amacıyla hazırlanmıştır.
