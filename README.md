# Oyun Mekanikleri

## Genel Bakış
Bu oyun, kaynak toplama ve işleme üzerine kurulu bir simülasyondur. Oyuncu ve AI karakter belirli görevleri yerine getirerek hammaddeyi işleyip satarak para kazanabilir. Her alanın belirli bir depolama kapasitesi vardır ve doluluk seviyesine dikkat edilmelidir.

---

## Oynanış Mekanikleri

### 1. Ağaç Kesme ve Kütük Toplama
- Karakter, etraftaki ağaçları keserek kütük elde eder.
- Kesilen ağaçlardan dökülen kütükleri toplayarak taşınabilir.
- Kütükler, **Spawner Makinesi** alanına götürülerek işlenir.

### 2. Spawner Makinesi
- Kütükleri tahtaya çevirir.
- Depolama kapasitesi dolduğunda işlem durur ve boşaltılması gerekir.
- AI karakter buradan tahtaları alarak taşır.

### 3. AI Karakterin Görevi
- AI karakter **Spawner Makinesi** alanından tahtaları alır.
- Tahtaları **Transformer Makinesi** alanına götürerek işlemeye devam eder.

### 4. Transformer Makinesi
- AI karakter tarafından getirilen tahtaları küplere dönüştürür.
- Depolama kapasitesi dolarsa, işlem durur ve boşaltılması gerekir.

### 5. Küpleri Satma
- Oyuncu, **Transformer Makinesi** tarafından üretilen küpleri **Para Alanına** götürebilir.
- Küpler satılarak para kazanılabilir.

### 6. Depolama Mekanizması
- Her alanın belirli bir **depolama sınırı** vardır.
- Eğer depolama kapasitesi dolarsa, ilgili işlem durur.
- Depolamanın azalması için içeriklerin başka alanlara taşınması veya satılması gereklidir.

### 7. Çöp Kutusu Alanı
- Hem oyuncu hem de AI karakter gereksiz eşyaları **Çöp Kutusu Alanına** götürerek yok edebilir.

---

## Strateji ve Dikkat Edilmesi Gerekenler
- **Depolama Kapasitelerini Yönetmek:** Depolama alanları dolarsa işlem durur, bu yüzden düzenli olarak eşyaları taşımak önemlidir.
- **AI Karakteri Verimli Kullanmak:** AI karakter, tahtaları taşımakla görevli olduğundan onun hareketlerini optimize etmek verimliliği artırır.
- **Hızlı Para Kazanma:** Küpleri hızlıca **Para Alanına** götürmek, kazancı maksimize etmek için önemlidir.

---

## Sonuç
Bu oyun, kaynak yönetimi ve işleme üzerine kurulu bir sistem sunmaktadır. Oyuncu ve AI karakter belirli görevleri yerine getirerek üretim sürecini sürdürmeli ve en iyi şekilde para kazanmalıdır.
