(function ($) {
    $(window).on('load', function () {

    });

    $(document).ready(function () {
        /*Menu sticky*/
        $(window).bind('scroll', function () {
            ($(window).scrollTop() > 179) ? $('#nav-menu-top').addClass('sticky') : $('#nav-menu-top').removeClass('sticky');
        });
        /*End Sticky*/
        /*Slider top*/
        function testi_slider() {
            if ($('.carousel-top').length) {
                $('.carousel-top').owlCarousel({
                    loop: true,
                    margin: 10,
                    items: 1,
                    autoplay: true,
                    autoplayHoverPause: true,
                    autoplaySpeed: 1500,
                    dots: true,
                    responsive: {
                        0: {
                            items: 1,
                            nav: false
                        }

                    }
                })
            }
        }
        testi_slider();
        /*End slider top*/
    });


})(window.jQuery);