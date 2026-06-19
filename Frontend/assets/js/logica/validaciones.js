function validarReglasReserva() {
    // Lógica pendiente
}
if (typeof module !== 'undefined' && module.exports) {
    module.exports = { esCapacidadValida };
}
function esCapacidadValida(cantidadIngresada, capacidadMaxima) {
    if (isNaN(cantidadIngresada) || isNaN(capacidadMaxima)) return false;
    return cantidadIngresada <= capacidadMaxima;
}