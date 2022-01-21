interface IActiveStickyFigure {
    figureImg: string | undefined
}

document.addEventListener('mousedown', function (ev) {
    if (document.getElementById('stickyFigure')) {
        document.getElementById('stickyFigure')!.style.transform = 'translateY(' + (ev.clientY) + 'px)';
        document.getElementById('stickyFigure')!.style.transform += 'translateX(' + (ev.clientX) + 'px)';
    }
}, false);

document.addEventListener('mousemove', function (ev) {
    if (document.getElementById('stickyFigure')) {
        document.getElementById('stickyFigure')!.style.transform = 'translateY(' + (ev.clientY) + 'px)';
        document.getElementById('stickyFigure')!.style.transform += 'translateX(' + (ev.clientX) + 'px)';
    }
}, false);

export default function ActiveStickyFigure({ figureImg }: IActiveStickyFigure) {
    return <div id='stickyFigure'><img src={figureImg} alt="stickyFigure" /></div>
}