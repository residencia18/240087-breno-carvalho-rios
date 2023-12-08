class Computador {
    constructor(nome, armazenamento, ram) {
        this.nome = nome;
        this.armazenamento = armazenamento + "GB";  
        this.ram = ram + "GB";
        this.ligado = false;
    }

    liga() {
        this.ligado = true;
    }

    desliga() {
        this.ligado = false;
    }
}

function getMap(computador) {
    return new Map(Object.entries(computador));
}

function criaLista(map, monitor) {
    let ul = document.createElement("ul");
    for (let [key, value] of map) {
        let li = document.createElement('li');
        li.innerText = `${key}: ${value}`;
        ul.append(li);
    }
    monitor.innerHTML = "";
    monitor.appendChild(ul);
}

function ligaPc() {
    let monitor = document.getElementById("monitor-frame");
    monitor.style.backgroundColor = "white";
    monitor.style.color = "black";
    monitor.innerText = "";
    setTimeout(() => {
        let map = getMap(pc);
        criaLista(map, monitor);
    }, 1000);
    pc.liga();
    
    let button = document.getElementById("btn-pc");
    button.innerText = "Desligar";
    button.style.backgroundColor = "DarkRed";
    button.removeEventListener('click', ligaPc);
    button.addEventListener('click', desligaPc);
}

function desligaPc() {
    let monitor = document.getElementById("monitor-frame");
    monitor.style.backgroundColor = "black";
    monitor.style.color = "white";
    monitor.innerText = "";
    setTimeout(() => {
        monitor.innerText = "Pressione Ligar";
    }, 1000);
    pc.desliga();

    let button = document.getElementById("btn-pc");
    button.innerText = "LIGAR";
    button.style.backgroundColor = "Green";
    button.removeEventListener('click', desligaPc);
    button.addEventListener('click', ligaPc);
}

document.getElementById("btn-pc").addEventListener('click', () => {
    if(pc == null) {
        return;
    }
    ligaPc()
});

document.getElementById("select-1").addEventListener('click', (event) => {
    if(pc != null) {
        desligaPc();
    }
    pc = pc1;

    event.target.style.backgroundColor = "black";
    document.getElementById("select-1").style.backgroundColor = "black";
    document.getElementById("select-2").style.backgroundColor = "darkcyan";
    document.getElementById("select-3").style.backgroundColor = "darkcyan";
});

document.getElementById("select-2").addEventListener('click', (event) => {
    if(pc != null) {
        desligaPc();
    }
    pc = pc2;

    event.target.style.backgroundColor = "black";
    document.getElementById("select-1").style.backgroundColor = "darkcyan";
    document.getElementById("select-3").style.backgroundColor = "darkcyan";
});

document.getElementById("select-3").addEventListener('click', (event) => {
    if(pc != null) {
        desligaPc();
    }
    pc = pc3;

    event.target.style.backgroundColor = "black";
    document.getElementById("select-1").style.backgroundColor = "darkcyan";
    document.getElementById("select-2").style.backgroundColor = "darkcyan";
});

let pc1 = new Computador("DESKTOP-001", 1000, 8);
let pc2 = new Computador("DESKTOP-002", 500, 16);
let pc3 = new Computador("DESKTOP-003", 240, 4);
let pc;