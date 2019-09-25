$('.review .owl-carousel').owlCarousel({
    loop: true,
    margin: 10,
    dots: true,
    autoplay: true,
    autoplayTimeout: 3000,
    responsive: {
        0: {
            items: 1
        },
        600: {
            items: 1
        },
        1000: {
            items: 1
        }
    }
})

$('.partners .owl-carousel').owlCarousel({
    loop: true,
    dots: true,
    autoplay: true,
    autoplayTimeout: 3000,
    responsive: {
        0: {
            items: 2
        },
        768: {
            items: 3
        },
        1000: {
            items: 5
        }
    }
})

$('.first-carousel .owl-carousel').owlCarousel({
    loop: false,
    margin: 10,
    dots: true,
    autoplay: false,
    autoplayTimeout: 3000,
    touchDrag: false,
    mouseDrag: false,
    responsive: {
        0: {
            items: 1
        },
        600: {
            items: 1
        },
        1000: {
            items: 1
        }
    }
})
$('.second-carousel .owl-carousel').owlCarousel({
    loop: true,
    margin: 10,
    dots: false,
    autoplay: true,
    autoplayTimeout: 3000,
    nav: true,
    navText: [''],
    responsive: {
        0: {
            items: 4
        },
        600: {
            items: 4
        },
        1000: {
            items: 4
        }
    }
})