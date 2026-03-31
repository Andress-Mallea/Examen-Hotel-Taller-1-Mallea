function switchSection(targetId) {
    const links = document.querySelectorAll('.nav-links a');
    const sections = document.querySelectorAll('main section');
    links.forEach(l => l.classList.remove('active'));
    sections.forEach(s => {
        s.style.display = 'none';
        s.classList.remove('active');
    });
    const activeLink = document.querySelector(`a[href="#${targetId}"]`);
    const targetSection = document.getElementById(targetId);

    if (activeLink) activeLink.classList.add('active');
    if (targetSection) {
        targetSection.style.display = 'block';
        targetSection.classList.add('active');
    }
    window.scrollTo({ top: 0, behavior: 'smooth' });
}
document.addEventListener('DOMContentLoaded', () => {
    const links = document.querySelectorAll('.nav-links a');

    links.forEach(link => {
        link.addEventListener('click', (e) => {
            e.preventDefault();
            const id = link.getAttribute('href').substring(1);
            switchSection(id);
        });
    });


    switchSection('seccion-huespedes');
});