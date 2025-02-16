# XoX Blog – Monolithic Architecture

Bu proje, .NET MVC ile geliştirilmiş monolitik bir blog sistemidir. CRUD işlemleri yapabilen, SEO uyumlu URL yapısına sahip, MySQL veritabanı ile çalışan bir yapı sunar.

## Özellikler
- Monolitik mimari
- MVC yapısı
- MySQL desteği
- SEO uyumlu URL yapısı
- CRUD işlemleri
- Admin paneli
- Kullanıcı oturumu ve güvenlik önlemleri

## Kurulum

### 1. Projeyi Çekme
```sh
 git clone https://github.com/medyababa/XoXBlogMono.git
 cd XoXBlogMono
```

### 2. Veritabanı Oluşturma

- PhpMyAdmin veya MySQL kullanarak veritabanını oluşturun.
- Aşağıdaki SQL dosyasını içe aktarın:

```
MySQL DOSYASI KÖK DİZİNDE.
```

### 3. Proje Bağımlılıklarını Yükleme

```sh
dotnet restore
```

### 4. Projeyi Çalıştırma
```sh
dotnet run
```
Projeyi tarayıcıda açmak için:
```
http://localhost:5229
```

## Veritabanı Bağlantısı ve Scaffold

Bağlantıyı yapılandırın ve entity sınıflarını oluşturun:

```sh
dotnet ef dbcontext scaffold "Server=localhost;User=dbkullanici;Password=sifre;Database=veritabaniadi" Pomelo.EntityFrameworkCore.MySql -o DBModels -f
```

## URL Yapısı

- `domain.com/category`
- `domain.com/category/yapay-zeka-1`
- `domain.com/category/entity-framework-3/neden-csharp-2-2`

## Panel Güvenliği

- Kullanıcı oturum yönetimi için Session kullanıldı.
- Panel işlemleri attribute middleware ile korundu.

## CRUD İşlemleri
- Ajax ile veri alışverişi sağlandı.
- ModelState.IsValid kullanılarak doğrulama yapıldı.

## Deploy

- Proje, Türkiye'deki popüler Windows Hosting sağlayıcılarında çalıştırılabilir.


