# Oyun Mekanikleri

apk dosyası: https://drive.google.com/file/d/1jerKAJBg_Mxhw0nAtkKocvUTYDSa2Wo3/view?usp=sharing
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


