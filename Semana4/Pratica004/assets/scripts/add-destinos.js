function destinoToDOM(destino){
    let div = document.createElement('div');
    div.innerHTML = createCard(destino);
    document.getElementById('destinos').appendChild(div);
}

document.getElementById('add-destino').addEventListener('submit', (event) => {
    event.preventDefault();

    let destinationName = document.getElementById('destino').value;
    let destinationPrice = document.getElementById('preco').value;
    let destinationImg = document.getElementById('imagem').value;
    
    let beneficios = [];
    let listaBeneficios = document.getElementById('lista-beneficios');
    for(li of listaBeneficios.children) {
        beneficios.push(li.innerText)
    }

    let detalhes = [];
    let listaDetalhes = document.getElementById('lista-detalhes-pagamento');
    for(li of listaDetalhes.children) {
        detalhes.push(li.innerText)
    }

    let destino = new Destino(
        title = destinationName,
        price = destinationPrice,
        img = {
            src: destinationImg,
            img: `Imagem de ${destinationName}`,
        },
        benefits = beneficios,
        extras = detalhes
    );

    salvaDestino(destino);
    destinoToDOM(destino);
});

function refreshDOM(){
    let listaDestinos = carregaDestinos();
    listaDestinos.forEach(destinoToDOM);
}

document.getElementById('add-beneficio').addEventListener('click', (event) => {
    event.preventDefault();

    let listaBeneficios = document.getElementById('lista-beneficios');
    let novoBeneficio = document.getElementById('novo-beneficio').value;
    let li = document.createElement('li');

    li.innerText = novoBeneficio;
    listaBeneficios.appendChild(li);    
    novoBeneficio = '';
});

document.getElementById('add-detalhe-pagamento').addEventListener('click', (event) => {
    event.preventDefault();

    let listaBeneficios = document.getElementById('lista-detalhes-pagamento');
    let novoDetalhePagamento = document.getElementById('novo-detalhe-pagamento').value;
    let li = document.createElement('li');

    li.innerText = novoDetalhePagamento;
    listaBeneficios.appendChild(li);
    novoDetalhePagamento = '';
});

refreshDOM();