const { RoomTypes, getRoomDisplayName } = require('../src/utils/RoomConstants.js');

test('devuelve el nombre legible segun la constante', () => {
    const nombre = getRoomDisplayName(RoomTypes.DOBLE_MATRIMONIAL);
    expect(nombre).toBe('Habitación Doble Matrimonial');
});