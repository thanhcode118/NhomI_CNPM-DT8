let currentIndex = 0;

function showSlides() {
    const slides = document.querySelectorAll('.slide');
    const totalSlides = slides.length;

    const slideTrack = document.querySelector('.slide-track');
    currentIndex++;

    // Reset về slide đầu tiên khi đến slide cuối
    if (currentIndex >= totalSlides) {
        currentIndex = 0;
    }

    // Dịch chuyển slide track để hiển thị slide hiện tại
    const translateXValue = -currentIndex * 100; // Tính khoảng cách dịch chuyển theo phần trăm
    slideTrack.style.transform = `translateX(${translateXValue}%)`;

    // Tự động chuyển slide mỗi 3 giây
    setTimeout(showSlides, 3000);
}

// Bắt đầu chuyển slide khi trang được tải
window.onload = function () {
    showSlides();
};
