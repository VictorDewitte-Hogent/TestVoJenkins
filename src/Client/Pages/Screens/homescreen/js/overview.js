const init = () => {
    document.getElementById("filter").addEventListener("click", (e) => {
        document.querySelector(".filter-wrapper").classList.toggle("filter-open");
        document.getElementById("filter").classList.toggle("filtericonclose");
    })
}

window.onload = init;