# csharp-did-you-mean-this
Bunumu demek istediniz ?

```csharp
string[] animals = { "kedi", "inek", "kobra" };

var corrector = new DidYouMeanThis
{
    Words = animals
};

Console.WriteLine(corrector.IsThis("kdi"));
// kedi

Console.WriteLine(corrector.IsThis("inök"));
// inek

Console.WriteLine(corrector.IsThis("kbr"));
// kobra
```
