async function cargarContactos() {
    const contenedor = document.querySelector('#contenedor-contactos');
    try {
        const response = await fetch('http://localhost:5206/api/Contacto');
        
        if (response.status === 404) {
            contenedor.innerHTML = `<p class="alert alert-warning">No hay contactos disponibles en este momento.</p>`;
            return;
        }

        const contactos = await response.json();
        contenedor.innerHTML = '';

        contactos.forEach(c => {
            contenedor.innerHTML += `
                <div class="col-md-3" style="border: 1px solid #ccc; padding: 10px; margin: 5px; border-radius: 8px;">
                    <h4>${c.nombreServicio}</h4>
                    <p><strong>Encargado:</strong> ${c.encargado}</p>
                    <p><strong>Teléfono:</strong> <a href="tel:${c.telefono}">${c.telefono}</a></p>
                </div>
            `;
        });
    } catch (error) {
        contenedor.innerHTML = `<p class="alert alert-danger">Error al conectar con el servidor.</p>`;
    }
}

document.addEventListener('DOMContentLoaded', cargarContactos);