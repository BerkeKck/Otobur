document.addEventListener("DOMContentLoaded", function () {
    const openBtn = document.getElementById('openHamburgerMenu');
    const closeBtn = document.getElementById('closeHamburgerMenu');
    const menu = document.getElementById('hamburgerMenu');
    const overlay = document.getElementById('hamburgerOverlay');

    if (openBtn && closeBtn && menu && overlay) {
        openBtn.addEventListener('click', () => {
            menu.classList.add('open');
            overlay.style.display = 'block';
        });
        closeBtn.addEventListener('click', () => {
            menu.classList.remove('open');
            overlay.style.display = 'none';
        });
        overlay.addEventListener('click', () => {
            menu.classList.remove('open');
            overlay.style.display = 'none';
        });
    }
});