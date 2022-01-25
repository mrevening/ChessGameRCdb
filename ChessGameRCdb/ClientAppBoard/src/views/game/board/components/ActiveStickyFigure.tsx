interface IActiveStickyFigure {
    figureImg: string | undefined
}





export default function ActiveStickyFigure({ figureImg }: IActiveStickyFigure) {
    const translate = (x: Number, y: Number) => {
        if (document.getElementById('stickyFigure')) {
            document.getElementById('stickyFigure')!.style.transform = 'translateX(' + x + 'px)';
            document.getElementById('stickyFigure')!.style.transform += 'translateY(' + y + 'px)';
        }
    }

    document.addEventListener('mousedown', function (ev) {
        translate(ev.clientX, ev.clientY)
    }, false);

    document.addEventListener('mousemove', function (ev) {
        translate(ev.clientX, ev.clientY)
    }, false);

    document.addEventListener('touchstart', function (ev) {
        var touch = ev.touches[0];
        translate(touch.pageX, touch.pageY)
    }, false);

    document.addEventListener('touchmove', function (ev) {
        var touch = ev.touches[0];
        translate(touch.pageX, touch.pageY)
    }, false);

    return <div id='stickyFigure'><img src={figureImg} alt="stickyFigure" /></div>
}