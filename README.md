# 🧪 LaboraTech – ASP.NET Core MVC Tabanlı Laboratuvar Yönetim Sistemi
LaboraTech, modern kullanıcı arayüzü ve güçlü mimarisiyle geliştirilmiş bir laboratuvar hizmet yönetim sistemidir. Proje **ASP.NET Core Web API**, **ASP.NET Core MVC yapısı** ve **Dapper ORM** kullanılarak, ***Stored Procedure*** üzerinden **ASP.NET Core Web API** aracılığıyla veritabanı işlemleri gerçekleştirecek şekilde inşa edilmiştir.

Geliştirilen API, veri işleme katmanını taşırken; şık ve dinamik arayüz, laboratuvar hizmetleri, ekip üyeleri, hakkında bilgileri ve kullanıcı referanslarını yönetilebilir kılar. Proje aynı zamanda **ViewComponent** destekli, tekrar kullanılabilir modüllerle donatılmıştır.


-----


## 💡 Projenin Öne Çıkan Özellikleri


### 🔗 RESTful Web API Entegrasyonu

• Projenin veri sağlayıcı katmanı, ayrı bir ASP.NET Core Web API projesi olarak yapılandırılmıştır.

• Tüm veri işlemleri (GET, POST, PUT, DELETE) bu API aracılığıyla gerçekleştirilir.

• Core MVC arayüzü, HttpClient ile API’ye bağlanarak içeriklerin güncel ve senkronize kalmasını sağlar.

• API tarafında Dapper ORM ile doğrudan Stored Procedure kullanılarak yüksek performanslı veri işleme sağlanır.



### 🌐 ASP.NET Core MVC + Dapper ORM + Stored Procedure

• ASP.NET Core MVC ile çok katmanlı yapı.

• Tüm CRUD işlemleri, Dapper aracılığıyla Stored Procedure üzerinden yapılır.

• SQL Server ile tam entegre, verimli veri işlemleri.


### 👩‍⚕️ Modüler Yapı – ViewComponent Kullanımı

• Navbar, Footer, İstatistik Kartları gibi bölümler ViewComponent ile yönetilir.

• Bu yapı, UI tarafında yeniden kullanılabilirlik ve modülerlik sağlar.


### 🧊 Glassmorphism Tasarım

• Tüm kartlar (Service, Team, Testimonial) şeffaf-buz (Glassmorphism) stilde tasarlanmıştır.

• Arka planlarda koyu filtreli görseller ile içerik ön plana çıkarılır.


### 👨‍🔬 Ekip Yönetimi (Team)

• 3 satırdan oluşan ekip kartları, her satır için farklı yönde kayan otomatik animasyon içerir.

• Kartlar arasında padding boşlukları ile şık bir görünüm korunur.


### 💬 Müşteri Yorumları (Testimonial)

• Carousel içinde kayan referans kartları.

• Kartlar saydam ve blur efektli olup beyaz alan kullanılmaz.

• Carousel okları içerde, stilize ve responsive.


### 📊 Admin Paneli

• About, Service, Team gibi modüller için CRUD işlemleri.

• API'ye veri gönderimi HttpClient ve JSON formatında yapılır.

• Kullanıcı dostu form tasarımları ve doğrulamalar yer alır.


-----


## 🩺 Kullanılan Teknolojiler


• ASP.NET Core Web API

• Dapper ORM

• Stored Procedures (SQL Server)

• ASP.NET Core MVC

• Microsoft SQL Server

• ViewComponent

• HTML5 / CSS3 / Bootstrap 5

• FontAwesome & Bootstrap Icons

• Owl Carousel, WOW.js, jQuery

• Modern CSS Animasyonları (keyframes, blur, glassmorphism)


-----


## 🖼️ Ekran Görüntüleri \& GIF’ler

\##### GIF animasyonları birkaç saniyede görüntülenebilir.




\### 🩺 Home Section


<img src="assets/LabHome.gif" width="700" alt="Homepage Animation" />


\### 🔎 About Section


<img src="assets/LabAbout.gif" width="700" alt="About Animation" />


\### 🔬 Service Section


<img src="assets/LabService.gif" width="700" alt="Service Animation" />


\### 👩‍⚕️ Team Section


<img src="assets/LabTeam.gif" width="700" alt="Team Animation" />


\### 👨‍👩‍👧‍👦 Testimonial Section


<img src="assets/Testimonial.gif" width="700" alt="Testimonial Animation" />






-----





