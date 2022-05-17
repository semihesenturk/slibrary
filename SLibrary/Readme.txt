Kullanılan Teknolojiler;
-.Net 6
-.Net Core Web Api (Dependency Injection Module, Swagger Open Api Implementation)
-Clean Code Architecture (Onion Architecture)
-Entity Framework Core (Code First, Repository Pattern)
-Bogus Fake Data Generator Tool
-Auto Mapper


Proje Gereksinimleri;
Projede Code First yaklaşımı mevcuttur. Projeyi ayağa kaldırmadan önce, Package Manager Console üzerinden update-database komutu verildikten sonra connectionstring'de belirtilen 
db üzerinde migration işlemi yapılacaktır. (Infrastructure.Persistent projesi default seçilmeli.)

Ardından webapi projesi set as startup yapılarak ayağa kaldırıldığında Seed datalar veritabanına doldurulacaktır.

Teşekkürler.