using System.Globalization;
using Pratica003;

CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");
ProductsController app = new();
app.run();
