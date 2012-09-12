MStrings
========

supports easier string manipulations
```csharp
string result = ContentScraper.For(s)
	.StartingAt("<").UntilLast(">")
	.Replace("<", "").Replace(">", "")
	.Replace("\r", "").Replace("\n", "")
	.Replace("&quot;", "\"")
	.Replace("&nbsp;", "");

```