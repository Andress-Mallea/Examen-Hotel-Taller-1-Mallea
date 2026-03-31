async function ejecutarCheckin(id) {
    if (!confirm("¿Confirmar ingreso del huésped?")) return;
    
    try {
        const response = await fetch(`http://localhost:5206/api/Reserva/${id}/checkin`, { method: 'PUT' });
        if (response.ok) {
            alert("Check-in registrado");
            listarReservas(); 
        }
    } catch (error) {
        console.error("Error en el check-in:", error);
    }
}

async function ejecutarCheckout(id) {
    if (!confirm("¿Confirmar salida del huésped?")) return;

    try {
        const response = await fetch(`http://localhost:5206/api/Reserva/${id}/checkout`, { method: 'PUT' });
        if (response.ok) {
            alert("Check-out registrado. Habitación liberada.");
            listarReservas(); 
        }
    } catch (error) {
        console.error("Error en el check-out:", error);
    }
}

async function listarReservas() {
    const tbody = document.querySelector('#body-reservas');
    if (!tbody) return;
    try {
        const response = await fetch('http://localhost:5206/api/Reserva');
        if (response.ok) {
            const reservas = await response.json();
            tbody.innerHTML = '';

            reservas.forEach(res => {
                const fila = document.createElement('tr');
                fila.innerHTML = `
                    <td>${res.idReserva}</td>
                    <td>${res.idHuespedNavigation?.nombre} ${res.idHuespedNavigation?.apellido}</td>
                    <td>Hab. ${res.idHabitacionNavigation?.numeroHabitacion}</td>
                    <td>${res.fechaIngreso}</td>
                    <td>${res.fechaSalida}</td>
                    <td><span class="badge-${res.estado}">${res.estado || 'Pendiente'}</span></td>
                    <td>
                        ${res.estado !== 'Hospedado' && res.estado !== 'Finalizada' ? 
                            `<button onclick="ejecutarCheckin(${res.idReserva})" class="btn-checkin">Check-in</button>` : ''}
                        ${res.estado === 'Hospedado' ? 
                            `<button onclick="ejecutarCheckout(${res.idReserva})" class="btn-checkout">Check-out</button>` : ''}
                    </td>
                `;
                tbody.appendChild(fila);
            });
        }
    } catch (error) {
        console.error("Error al listar reservas:", error);
    }
}
document.addEventListener('DOMContentLoaded', () => {
    const formReserva = document.querySelector('#form-nueva-reserva');
    const selectHabitacion = document.querySelector('#id-habitacion');
    const selectorVar = document.querySelector('#selector-variacion');
    const divDetalle = document.querySelector('#detalle-variacion');
    selectorVar.addEventListener('change', async () => {
        const tipo = selectorVar.value;
        if (!tipo) {
            divDetalle.style.display = 'none';
            return;
        }

        try {
            const response = await fetch(`http://localhost:5206/api/Habitacion/variacion/${tipo}`);
            if (response.ok) {
                const data = await response.json();
                document.querySelector('#span-capacidad').textContent = data.capacidad;
                document.querySelector('#span-precio').textContent = data.precioBase;
                document.querySelector('#p-descripcion').textContent = data.descripcion;
                divDetalle.style.display = 'block';
            }
        } catch (error) {
            console.error("Error al obtener variación:", error);
        }
    });
    listarReservas(); 

    async function cargarHabitaciones() {
        try {
            const response = await fetch('http://localhost:5206/api/Habitacion');
            if (response.ok) {
                const habitaciones = await response.json();
                selectHabitacion.innerHTML = '<option value="">Seleccione una habitación...</option>';
                
                habitaciones.forEach(hab => {
                    const option = document.createElement('option');
                    option.value = hab.idHabitacion;
                    option.textContent = `Habitación ${hab.numeroHabitacion} (Piso ${hab.piso})`;
                    selectHabitacion.appendChild(option);
                });
            }
        } catch (error) {
            console.error("Error al cargar habitaciones:", error);
        }
    }

    cargarHabitaciones();
    if(formReserva) {
        formReserva.addEventListener('submit', async (e) => {
            e.preventDefault();
            if (!selectorVar.value) {
                alert("Error: Debe seleccionar una variación válida de habitación.");
                return;
            }

            const nuevaReserva = {
                idHuesped: parseInt(document.querySelector('#id-huesped-reserva').value),
                idHabitacion: parseInt(selectHabitacion.value),
                fechaIngreso: document.querySelector('#fecha-ingreso').value,
                fechaSalida: document.querySelector('#fecha-salida').value,
                cantidadPersonas: 1,
                estado: "Pendiente"
            };

            try {
                const response = await fetch('http://localhost:5206/api/Reserva', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(nuevaReserva)
                });

                if (response.ok) {
                    alert("¡Reserva creada con éxito!");
                    listarReservas();
                    formReserva.reset();
                    divDetalle.style.display = 'none'; 
                } else {
                    const data = await response.json();
                    alert("Error: " + (data.message || "No se pudo crear la reserva"));
                }
            } catch (error) {
                alert("No se pudo conectar con el servidor.");
            }
        });
    }
});