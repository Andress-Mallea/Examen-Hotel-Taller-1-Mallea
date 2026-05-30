function validarReglasReserva() {
    // Lógica pendiente
}
module.exports = { validarReglasReserva };
export function esCapacidadValida(cantidadIngresada, capacidadMaxima) {
    if (isNaN(cantidadIngresada) || isNaN(capacidadMaxima)) return false;
    return cantidadIngresada <= capacidadMaxima;
}