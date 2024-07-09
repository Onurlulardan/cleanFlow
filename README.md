
# CleanFlow: Temizlik Otomasyonu Backend

CleanFlow, .NET Core kullanılarak geliştirilmiş, temizlik operasyonlarını otomatikleştiren bir backend çözümüdür. Temizlik personeline görev atar, günlük iş emirleri oluşturur ve fotoğraflar aracılığıyla raporlama sağlar.

## Özellikler
- **Temizlik Görevleri:** Temizlenecek tuvaletler ve diğer alanlar otomatik olarak personellere atanır.
- **Günlük İş Emirleri:** Her gün için otomatik iş emirleri oluşturulur.
- **Temizlik Raporlama:** Temizlik tamamlandıktan sonra personeller fotoğraflar ile raporlama yapar.
- **Denetçi Modülü:** Denetçiler temizlik durumunu, personellerin performansını ve lokasyon bilgilerini izler.
- **Detaylı Raporlar:** Temizlik istatistikleri, personel performansı ve lokasyona göre detaylı raporlar sunulur.

## Kullanım
- **API Dokümantasyonu:** [API dökümantasyonuna buradan ulaşın](https://cleanflowbe.altuntasonur.com/swagger/index.html).
- **Web Arayüzü:** [Web arayüzüne buradan erişin](https://cleanflow.altuntasonur.com/) (Kullanıcı adı: admin, şifre: admin).
- **Dapper Entegrasyonu:** `appsettings.json` dosyasındaki `ConnectionStrings` alanını kendi veritabanı bilgileriniz ile doldurun.

## Gelişmiş Bilgiler
- **NodeJS Versiyonu:** NodeJS ile yazılmış eski bir versiyon mevcuttur.
- **React Web Arayüzü:** Web arayüzü React ile geliştirilmiştir.
- **Mobil Uygulama (Android):** Mobil uygulama halen geliştirme aşamasındadır.

## Notlar
- **Authorize:** Geliştirme aşamasındayken yetkilendirmeyi devre dışı bıraktım. `[Authorize]` ekleyerek yetkilendirmeyi etkinleştirebilirsiniz.
- **Fotoğraf Yükleme:** Mobil uygulama galeriden fotoğraf yükleme yerine anlık fotoğraf çekme özelliği sunmaktadır.

## Proje Hakkında
CleanFlow, hobi amaçlı geliştirilmiş bir temizlik otomasyonu backend'idir. .NET Core bilgilerimi geliştirmek için bu projeyi sürdürmekteyim. Projeyi boş kaldıkça güncelliyorum.

## Daha Fazla Bilgi ve Destek
- **API Dokümantasyonu:** [Buradan ulaşabilirsiniz](https://cleanflowbe.altuntasonur.com/swagger/index.html).
- **Web Arayüzü:** [Buradan erişin](https://cleanflow.altuntasonur.com/).
- **Sorular ve Destek:** Herhangi bir sorunuz veya geri bildiriminiz varsa, lütfen bana mesaj atın.
