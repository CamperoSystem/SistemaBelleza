function toggleSidebar() {
    const sidebar = document.getElementById('sidebar');
    const main = document.getElementById('main');
    const header = document.getElementById('header');

    sidebar.classList.toggle('hidden');
    main.classList.toggle('expanded');
    header.classList.toggle('expanded');
}
