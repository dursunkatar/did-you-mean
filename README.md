# csharp-js-did-you-mean-this

![did you mean this](https://github.com/dursunkatar/csharp-js-did-you-mean-this/blob/master/google-did-you-mean-this.jpg)

Bunumu demek istediniz ?

Yazılan yanlış kelimeyi,kelime dizisindeki diğer kelimelerle karşılaştırarak yanlış kelimeye en çok benzeyeneni bulup doğru kelimeyi tespit eder

### C sharp Örnek
```csharp
string[] words = { "google","kitap", "kobra" };

var corrector = new DidYouMeanThis
{
    Words = words
};

Console.WriteLine(corrector.IsThis("gogıl"));
// google
Console.WriteLine(corrector.IsThis("kitob"));
// kitap
Console.WriteLine(corrector.IsThis("kbr"));
// kobra
```

### javascript Örnek

```js
let words = ["google", "kitap", "kobra"];

let corrector = new DidYouMeanThis(words);

console.log(corrector.isThis("gogıl"))
// google
console.log(corrector.isThis("kitob"))
// kitap
console.log(corrector.isThis("kbr"))
// kobra
```
