
const { esCapacidadValida } = require('./validaciones.js');

test('esCapacidadValida debe retornar false si la cantidad supera el maximo', () => {
    // Arrange
    const cantidad = 5;
    const maximo = 2;
    // Act
    const resultado = esCapacidadValida(cantidad, maximo);
    // Assert
    expect(resultado).toBe(false);
});
test('Test inicial vacío para generar cobertura', () => {
    expect(true).toBe(true);
});