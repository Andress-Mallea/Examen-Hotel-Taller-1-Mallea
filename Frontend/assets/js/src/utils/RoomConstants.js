
const RoomTypes = {
    SIMPLE: 'simple',
    DOBLE_CAMAS_INDIVIDUALES: 'doble_camas_individuales',
    DOBLE_MATRIMONIAL: 'doble_matrimonial',
    SUITE: 'suite'
};

const DEFAULT_ROOM_CAPACITY = 2;
const DEFAULT_ROOM_HAS_WIFI = true;
const DEFAULT_ROOM_HAS_AC = true;

const RoomCapacities = {
    [RoomTypes.SIMPLE]: 1,
    [RoomTypes.DOBLE_CAMAS_INDIVIDUALES]: 2,
    [RoomTypes.DOBLE_MATRIMONIAL]: 2,
    [RoomTypes.SUITE]: 4
};
const DEFAULT_SIMPLE_PRICE = 150;
const DEFAULT_DOBLE_CAMAS_INDIVIDUALES_PRICE = 250;
const DEFAULT_DOBLE_MATRIMONIAL_PRICE = 280;
const DEFAULT_SUITE_PRICE = 350;


const RoomDisplayNames = {
    [RoomTypes.SIMPLE]: 'Habitación Simple',
    [RoomTypes.DOBLE_CAMAS_INDIVIDUALES]: 'Habitación Doble con Camas Individuales',
    [RoomTypes.DOBLE_MATRIMONIAL]: 'Habitación Doble Matrimonial',
    [RoomTypes.SUITE]: 'Suite'
};


const RoomPrices = {
    [RoomTypes.SIMPLE]: DEFAULT_SIMPLE_PRICE,
    [RoomTypes.DOBLE_CAMAS_INDIVIDUALES]: DEFAULT_DOBLE_CAMAS_INDIVIDUALES_PRICE,
    [RoomTypes.DOBLE_MATRIMONIAL]: DEFAULT_DOBLE_MATRIMONIAL_PRICE,
    [RoomTypes.SUITE]: DEFAULT_SUITE_PRICE
};

/**
 * Obtiene el nombre descriptivo de una habitación
 * @param {string} roomType 
 * @returns {string} 
 */
function getRoomDisplayName(roomType) {
    return RoomDisplayNames[roomType] || 'Habitación Desconocida';
}

/**
 * Obtiene el precio de una habitación
 * @param {string} roomType 
 * @returns {number} 
 */
function getRoomPrice(roomType) {
    return RoomPrices[roomType] || 0;
}

/**
 * Obtiene la capacidad de una habitación
 * @param {string} roomType 
 * @returns {number} 
 */
function getRoomCapacity(roomType) {
    return RoomCapacities[roomType] || 1;
}

/**
 * Obtiene la configuración por defecto de una habitación
 * @returns {Object} 
 */
export function getDefaultRoomSetup() {
    return {
        capacity: DEFAULT_ROOM_CAPACITY,
        hasWifi: DEFAULT_ROOM_HAS_WIFI,
        hasAC: DEFAULT_ROOM_HAS_AC
    };
}

module.exports = {
    RoomTypes,
    RoomCapacities,
    RoomDisplayNames,
    RoomPrices,
    getRoomDisplayName,
    getRoomPrice,
    getRoomCapacity,
    getDefaultRoomSetup,
    DEFAULT_SIMPLE_PRICE,
    DEFAULT_DOBLE_CAMAS_INDIVIDUALES_PRICE,
    DEFAULT_DOBLE_MATRIMONIAL_PRICE,
    DEFAULT_SUITE_PRICE,
    DEFAULT_ROOM_CAPACITY,
    DEFAULT_ROOM_HAS_WIFI,
    DEFAULT_ROOM_HAS_AC
};
