class Computador {
    constructor(armazenamento) {
        this.programasInstalados = []
        this.armazenamento = armazenamento;  
        this.ligado = false;
    }

    liga() {
        this.ligado = true;
    }

    desliga() {
        this.ligado = false;
    }

    instalaPrograma(programa) {
        if(programa.tamanho > this.armazenamento) {
            return false;
        }

        this.armazenamento -= programa.tamanho;
        this.programasInstalados.push(programa);
    }

    desinstalaPrograma(programa) {
        this.armazenamento += programa.tamanho;
        this.programasInstalados.slice(this.programasInstalados.indexOf(programa), 1);
    }
}

