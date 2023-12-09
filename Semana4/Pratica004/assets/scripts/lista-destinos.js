function translateButton(button) {
    button.style.transform = "translateY(1.7em)";
    button.style.border = "3px solid white";
    button.style.backgroundColor = "white";
}

function destinoToDOM(destino){
    let div = document.createElement('div');
    div.innerHTML = createCard(destino);
    document.querySelector('main').appendChild(div);
}

function getDataFromDOM(element) {
    let title = element.querySelector('.title').innerHTML;
    let price = element.querySelector('.price').innerHTML;
    let img = element.querySelector('.img');
    let benefits = element.querySelector('.benefits');
    let extras = element.querySelector('.price-details');
    let destino = new Destino(title, price, {src: img.src, alt: img.alt}, getDataFromList(benefits), getDataFromList(extras));
    console.log(JSON.stringify(destino));
}

function refreshDOM(){
    let listaDestinos = carregaDestinos();
    listaDestinos.forEach(destinoToDOM);
}

refreshDOM();