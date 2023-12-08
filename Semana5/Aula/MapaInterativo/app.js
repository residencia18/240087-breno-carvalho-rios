fetch('https://restcountries.com/v3.1/all')
    .then(function (resposta) { return resposta.json(); })
    .then(function (paises) { return paises.map(function (pais) { return {name: pais.name.common, latlng: pais.latlng}; }); })
    .then(function (paises) {
      for (pais of paises) {
        let opt = document.createElement("option");
        opt.value = pais.latlng;
        opt.innerText = pais.name;
        document.getElementById("paises").appendChild(opt);
      }
    })
    .catch(function (error) { return console.error('Erro com a chamada fetch: ', error); });

var map = L.map('map').setView([-14.794851092521004, -39.25978803993592], 4);
document.getElementById("paises").addEventListener('change', (event) => {
  let params = event.target.value.split(',');
  map.setView(params, 4);
});

L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
  maxZoom: 19,
}).addTo(map);