async function verDetalleHuesped(id) {
    try {
        const response = await fetch(`http://localhost:5206/api/Huesped/${id}`);
        if (!response.ok) return;

        const h = await response.json();
        const resReservas = await fetch(`http://localhost:5206/api/Huesped/reservas/${id}`);
        if (resReservas.ok) console.log("Hola");
        const reservas = await resReservas.json();
       
        document.querySelector('#det-nombre').textContent = `${h.nombre} ${h.apellido}`;
        document.querySelector('#det-documento').textContent = h.documentoIdentidad;
        document.querySelector('#det-telefono').textContent = h.telefono || 'No registrado';
        document.querySelector('#det-correo').textContent = h.correo || 'No registrado';
        const modal = document.querySelector('#modal-detalle-huesped');
        modal.style.display = 'flex'; 
        const contenedorReservas = document.querySelector('#lista-reservas-huesped');
        contenedorReservas.innerHTML = ''; 

        if (reservas.length === 0) {
            contenedorReservas.innerHTML = '<p>No hay historial de estadías finalizadas.</p>';
        } else {
            const agrupadas = reservas.reduce((agru, r) => {
                const tipo = r.idHabitacionNavigation?.idTipoNavigation?.denominacion;
                if (!agru[tipo]) agru[tipo] = [];
                agru[tipo].push(r);
                return agru;
            }, {});
            for (const tipo in agrupadas) {
                const tituloGrupo = document.createElement('div');
                tituloGrupo.textContent = `Categoria: ${tipo}`;
                contenedorReservas.appendChild(tituloGrupo);
                let numero_reservas = 0;
                agrupadas[tipo].forEach(r => {
                    numero_reservas = numero_reservas +1;
                });
                const item = document.createElement('div');
                    item.innerHTML = `
                        <span><b>Numero de estadias: ${numero_reservas}</b></span> 
                    `;
                    contenedorReservas.appendChild(item);
            }
        }
    } catch (error) {
        console.error("Error al ver detalle:", error);
    }
}

function cerrarDetalleHuesped() {
    document.querySelector('#modal-detalle-huesped').style.display = 'none';
}
async function listarHuespedes() {
    const tbody = document.querySelector('#body-huespedes');
    if (!tbody) return;
    try {
        const response = await fetch('http://localhost:5206/api/Huesped');
        if (response.ok) {
            const reservas = await response.json();
            tbody.innerHTML = '';

            reservas.forEach(res => {
            const fila = document.createElement('tr');
            fila.innerHTML = `
                <td>${res.documentoIdentidad}</td>
                <td>${res.nombre} ${res.apellido}</td>
                <td>
                    <button onclick="verDetalleHuesped(${res.idHuesped})" class="btn-consultar" style="background:none; color:var(--accent); padding:0; border:none; text-decoration:underline;">
                         Consultar
                    </button>
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
    listarHuespedes();
});
const formHuesped = document.querySelector('#form-huesped');

if (formHuesped) {
    formHuesped.addEventListener('submit', async (e) => {
        e.preventDefault();
        
        const nuevoHuesped = {
            nombre: document.querySelector('#nombre-huesped').value,
            apellido: document.querySelector('#apellido-huesped').value,
            documentoIdentidad: document.querySelector('#doc-huesped').value,
            correo: document.querySelector('#correo-huesped').value,
            telefono: document.querySelector('#tel-huesped').value
        };

        try {
            const response = await fetch('http://localhost:5206/api/Huesped', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(nuevoHuesped)
            });

            if (response.ok) {
                alert("Huésped registrado con éxito");
                listarHuespedes();
                formHuesped.reset();
            }
        } catch (error) {
            console.error("Error al registrar huésped:", error);
        }
    });
}