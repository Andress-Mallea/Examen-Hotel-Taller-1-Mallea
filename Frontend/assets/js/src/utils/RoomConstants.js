// Constantes de tipos de habitaciones
const RoomTypes = {
    SIMPLE: 'simple',
    DOBLE_CAMAS_INDIVIDUALES: 'doble_camas_individuales',
    DOBLE_MATRIMONIAL: 'doble_matrimonial',
    SUITE: 'suite'
};

// Mapping de tipos de habitación a nombres descriptivos
const RoomDisplayNames = {
    [RoomTypes.SIMPLE]: 'Habitación Simple',
    [RoomTypes.DOBLE_CAMAS_INDIVIDUALES]: 'Habitación Doble con Camas Individuales',
    [RoomTypes.DOBLE_MATRIMONIAL]: 'Habitación Doble Matrimonial',
    [RoomTypes.SUITE]: 'Suite'
};

// Precios de las habitaciones
const RoomPrices = {
    [RoomTypes.SIMPLE]: 150,
    [RoomTypes.DOBLE_CAMAS_INDIVIDUALES]: 250,
    [RoomTypes.DOBLE_MATRIMONIAL]: 280,
    [RoomTypes.SUITE]: 350
};

/**
 * Obtiene el nombre descriptivo de una habitación
 * @param {string} roomType - El tipo de habitación
 * @returns {string} El nombre descriptivo de la habitación
 */
function getRoomDisplayName(roomType) {
    return RoomDisplayNames[roomType] || 'Habitación Desconocida';
}

/**
 * Obtiene el precio de una habitación
 * @param {string} roomType - El tipo de habitación
 * @returns {number} El precio de la habitación
 */
function getRoomPrice(roomType) {
    return RoomPrices[roomType] || 0;
}

module.exports = {
    RoomTypes,
    RoomDisplayNames,
    RoomPrices,
    getRoomDisplayName,
    getRoomPrice
};
