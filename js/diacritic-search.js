export function normalizeInput(inputElement) {
    if (!inputElement) return;

    const normalize = (text) => {
        if (!text) return '';
        return text.normalize('NFD').replace(/[\u0300-\u036f]/g, '');
    };

    // Store original value setter
    const valueDescriptor = Object.getOwnPropertyDescriptor(HTMLInputElement.prototype, 'value');

    // Override the value property setter to normalize on assignment
    Object.defineProperty(inputElement, 'value', {
        get() {
            return valueDescriptor.get.call(this);
        },
        set(newValue) {
            const normalized = normalize(newValue);
            valueDescriptor.set.call(this, normalized);
        }
    });

    // Listen to input events and normalize
    inputElement.addEventListener('input', (e) => {
        const normalized = normalize(inputElement.value);
        if (normalized !== inputElement.value) {
            inputElement.value = normalized;
        }
    });

    // Also listen to keydown to prevent accented characters from being typed
    inputElement.addEventListener('keydown', (e) => {
        // Allow normal keys, just normalize on input event
    });
}

export function hookMatBlazorAutocomplete() {
    // Wait for MatBlazor to render its input field
    const waitForInput = setInterval(() => {
        const inputs = document.querySelectorAll('.mdc-text-field__input');
        if (inputs.length > 0) {
            clearInterval(waitForInput);
            inputs.forEach(input => {
                // Only normalize the autocomplete search input in the header
                if (input.closest('.header-search')) {
                    normalizeInput(input);
                }
            });
        }
    }, 100);

    // Stop waiting after 5 seconds
    setTimeout(() => clearInterval(waitForInput), 5000);
}

// Auto-hook when the DOM is ready
if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', hookMatBlazorAutocomplete);
} else {
    hookMatBlazorAutocomplete();
}



