

const clickRead = () => {
    document.querySelectorAll(".not-read").forEach(setAllRead);
}

const setAllRead = (item, index, arr) => {
    item.classList.remove("not-read");
}
