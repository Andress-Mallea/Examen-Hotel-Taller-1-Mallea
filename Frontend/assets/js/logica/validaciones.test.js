const { esCapacidadValida } = require('./validaciones.js');

test('debe rechazar cuando los huespedes superan el limite de la habitacion', () => {
    const ingresados = 5;
    const limite = 2;
    
    const esValido = esCapacidadValida(ingresados, limite);
    
    expect(esValido).toBe(false);
});

test('debe aceptar cuando los huespedes estan dentro del limite', () => {
    expect(esCapacidadValida(2, 4)).toBe(true);
});