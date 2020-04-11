# ArticleApp
------------------------------

Veritabanı olarak MongoDb kullanılmıştır 
iki adet controller mevcuttur; 
SeedController : İlgili test datalarını yükler Bu Controllerdan gelen Result'da Array içinde Hem User hem de Article ve Category Bilgileri çıkmaktadır. Swagger UI üzerinden response'da görebilirsiniz. Oradaki İlgili Id bilgilerini kullanarak işlemlerinizi yapabilirsiniz.

ArticleController: İlgili caselerin gerçekleştiği senaryodur.

http://localhost:5200/swagger/index.html üzerinden testi gerçekleştirebilirsiniz.

MongoDb LocalHost Url= "mongodb://localhost:27017" (MongoDb Compass Programında connection girdisine yazmanız yeterli olacaktır.)

*Proje'de katmanlı mimarı yapısı kullanıldı. (Data, Business ve API katmanı olmak üzere)
*Proje'de kullanılan MongoDB, FluentValidator vb. uygulamalar hakkında önceki projelerimde de tecrübem vardı.
*Geniş vaktim olsaydı Makale ekleme aksiyonlarında daha çok validasyon kullanırdım. AutoMapper vb. bileşenleri kullanabilirdim.

-- İsmail Can KARAMAN 
