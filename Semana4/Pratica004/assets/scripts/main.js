class Destino {
    constructor(title, price, img, benefits, extras){
        this.title = title;
        this.price = price;
        this.img = img;
        this.benefits = benefits;
        this.extras = extras;
    }
}

let salvador = new Destino(
    title = "Salvador",
    price = 670.00,
    img = {
        src: "assets/imgs/salvador.jpg",
        alt: "Imagem Salvador"
    },
    benefits = [
        "Aéreo",
        "03 diárias",
        "Café da Manhã"
    ],
    extras = [
        "Taxas Inclusas",
        "Em até 10x sem Juros"
    ]
);

let fortaleza = new Destino(
    title = "Fortaleza",
    price = 1513.00,
    img = {
        src: "assets/imgs/fortaleza.jpg",
        alt: "Imagem Fortaleza"
    },
    benefits = [
        "Aéreo ida e volta",
        "06 diárias",
        "Café da Manhã"
    ],
    extras = [
        "Taxas Inclusas",
        "Em até 10x sem Juros"
    ]
);

let campinas = new Destino(
    title = "Campinas",
    price = 900.00,
    img = {
        src: "assets/imgs/campinas.jpg",
        alt: "Imagem Campinas"
    },
    benefits = [
        "Aéreo ida e volta",
        "04 diárias",
        "Café da Manhã"
    ],
    extras = [
        "Taxas Inclusas",
        "Em até 10x sem Juros"
    ]
);

function createCard(destino) {
    return `
        <div id="${destino.title}" class="card">
            <img class="img" src="${destino.img.src}" alt="${destino.img.alt}">
            <h2 class="title">${destino.title}</h2>
            <ul class="benefits">
                ${ destino.benefits.map(benefit => `<li>${benefit}</li>`).join(" ") }
            </ul>
            
            <div class="payment-info">
                <p class="price">R$ ${destino.price}</p>
                <div class="price-details">
                    ${ destino.extras.map(extra => `<p>${extra}</p>`).join(" ") }
                </div>
            </div>
            
            <div class="card-div" onclick="translateButton(this)">
                <button id="btn-${destino.title}" onclick="getDataFromDOM(${destino.title})">Comprar</button>
            </div>
        </div>
    `
}

function carregaDestinos(){
    let listaDestinos = localStorage.getItem('lista-destinos');
    if(listaDestinos == null) {
        return [salvador, fortaleza, campinas];
    }
    return JSON.parse(listaDestinos);
}

function salvaDestino(destino){
    let listaDestinos = carregaDestinos();
    listaDestinos.push(destino);
    localStorage.setItem('lista-destinos', JSON.stringify(listaDestinos));
}

function getDataFromList(ul){
    let list = []
    for(li of ul.children) {
        list.push(li.innerText)
    }
    return list;
}