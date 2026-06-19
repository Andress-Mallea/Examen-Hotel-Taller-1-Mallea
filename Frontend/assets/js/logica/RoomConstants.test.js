const { RoomTypes, getRoomDisplayName } = require('../src/utils/RoomConstants.js');

test('getRoomDisplayName debe retornar la etiqueta correcta usando la constante', () => {
    // Arrange & Act
    const etiqueta = getRoomDisplayName(RoomTypes.DOBLE_MATRIMONIAL);
    
    // Assert
    expect(etiqueta).toBe('Habitación Doble Matrimonial');
});