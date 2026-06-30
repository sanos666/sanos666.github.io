let tooltipEl = null;
let initialized = false;

function ensureTooltip() {
    if (tooltipEl) return tooltipEl;
    tooltipEl = document.createElement('div');
    tooltipEl.className = 'progress-tooltip';
    tooltipEl.setAttribute('role', 'tooltip');
    tooltipEl.style.display = 'none';
    document.body.appendChild(tooltipEl);
    return tooltipEl;
}

function showTooltip(dot, clientX, clientY) {
    const tip = ensureTooltip();
    const series = dot.getAttribute('data-series') || '';
    const value = dot.getAttribute('data-value') || '';
    const season = dot.getAttribute('data-season') || '';
    const color = dot.getAttribute('data-color') || '#fff';

    tip.innerHTML =
        '<span class="progress-tooltip-dot" style="background:' + color + '"></span>' +
        '<span class="progress-tooltip-series">' + series + '</span>' +
        '<span class="progress-tooltip-value">' + value + '</span>' +
        '<span class="progress-tooltip-season">' + season + '</span>';

    tip.style.display = 'flex';
    positionTooltip(clientX, clientY);
}

function positionTooltip(clientX, clientY) {
    if (!tooltipEl) return;
    const offset = 14;
    const rect = tooltipEl.getBoundingClientRect();
    let left = clientX + offset;
    let top = clientY + offset;

    if (left + rect.width > window.innerWidth - 8) {
        left = clientX - rect.width - offset;
    }
    if (top + rect.height > window.innerHeight - 8) {
        top = clientY - rect.height - offset;
    }

    tooltipEl.style.left = Math.max(8, left) + 'px';
    tooltipEl.style.top = Math.max(8, top) + 'px';
}

function hideTooltip() {
    if (tooltipEl) tooltipEl.style.display = 'none';
}

export function initProgressTooltips() {
    if (initialized) return;
    initialized = true;

    document.addEventListener('pointerover', (e) => {
        const dot = e.target.closest && e.target.closest('.progress-dot');
        if (dot) showTooltip(dot, e.clientX, e.clientY);
    });

    document.addEventListener('pointermove', (e) => {
        if (tooltipEl && tooltipEl.style.display !== 'none') {
            positionTooltip(e.clientX, e.clientY);
        }
    });

    document.addEventListener('pointerout', (e) => {
        const dot = e.target.closest && e.target.closest('.progress-dot');
        if (dot) hideTooltip();
    });

    // Hide on scroll to avoid a stuck tooltip.
    document.addEventListener('scroll', hideTooltip, true);
}
