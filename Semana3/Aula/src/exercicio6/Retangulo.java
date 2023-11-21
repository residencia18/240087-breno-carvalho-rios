package exercicio6;

public class Retangulo {
	float altura, largura;
	
	public static void main(String[] args) {
		float altura = 10;
		float largura = 20;
		Retangulo retangulo = new Retangulo(altura, largura);
		
		System.out.println("A área do triangulo é: " + retangulo.area());
	}
	
	public Retangulo(float _largura, float _altura) {
		this.largura = _largura;
		this.altura = _altura;
	}
	
	public float area() {
		return largura * altura;
	}
}
