document.addEventListener("DOMContentLoaded", () => {
    console.log("Dashboard listo ✅");

    // Contador progresivo animado
    const counters = document.querySelectorAll(".counter");
    counters.forEach(counter => {
        const updateCount = () => {
            const target = +counter.getAttribute("data-target");
            const count = +counter.innerText;
            const increment = Math.ceil(target / 50);

            if (count < target) {
                counter.innerText = Math.min(count + increment, target);
                setTimeout(updateCount, 20);
            } else {
                counter.innerText = target;
            }
        };

        updateCount();
    });

    // Animación al hacer clic (opcional)
    document.querySelectorAll(".dashboard-card").forEach(card => {
        card.addEventListener("click", () => {
            card.classList.add("animate__pulse");
            setTimeout(() => card.classList.remove("animate__pulse"), 800);
        });
    });
});
