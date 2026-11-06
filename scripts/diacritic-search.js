const normalize = (text) => {
    if (!text) return '';
    return text.normalize('NFD').replace(/[\u0300-\u036f]/g, '').normalize('NFC');
};

let composing = false;

function isSearchInput(target) {
    return target instanceof HTMLInputElement
        && target.classList.contains('mdc-text-field__input')
        && target.closest('.header-search') !== null;
}

function normalizeInPlace(input) {
    const value = input.value;
    const normalized = normalize(value);
    if (normalized === value) return;

    const caret = input.selectionStart;
    const removed = value.length - normalized.length;
    input.value = normalized;
    if (caret !== null) {
        const pos = Math.max(0, caret - removed);
        try { input.setSelectionRange(pos, pos); } catch { /* unsupported input type */ }
    }
}

export function hookMatBlazorAutocomplete() {
    if (window.__diacriticSearchHooked) return;
    window.__diacriticSearchHooked = true;

    // Delegated capture-phase listeners survive MatBlazor re-renders and run before Blazor reads the value.
    document.addEventListener('compositionstart', e => {
        if (isSearchInput(e.target)) composing = true;
    }, true);

    document.addEventListener('compositionend', e => {
        if (!isSearchInput(e.target)) return;
        composing = false;
        normalizeInPlace(e.target);
        e.target.dispatchEvent(new Event('input', { bubbles: true }));
    }, true);

    document.addEventListener('input', e => {
        if (!isSearchInput(e.target) || composing || e.isComposing) return;
        normalizeInPlace(e.target);
    }, true);
}

hookMatBlazorAutocomplete();
