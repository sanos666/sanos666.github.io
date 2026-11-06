const DB_NAME = 'omh-data-cache';
const STORE = 'files';
const DB_VERSION = 1;

let dbPromise = null;

function openDb() {
    if (dbPromise) return dbPromise;
    dbPromise = new Promise((resolve, reject) => {
        if (!('indexedDB' in globalThis)) {
            reject(new Error('IndexedDB is not available'));
            return;
        }
        const request = indexedDB.open(DB_NAME, DB_VERSION);
        request.onupgradeneeded = () => {
            const db = request.result;
            if (!db.objectStoreNames.contains(STORE)) {
                db.createObjectStore(STORE);
            }
        };
        request.onsuccess = () => resolve(request.result);
        request.onerror = () => reject(request.error);
    });
    dbPromise.catch(() => { dbPromise = null; });
    return dbPromise;
}

function run(mode, action) {
    return openDb().then(db => new Promise((resolve, reject) => {
        const tx = db.transaction(STORE, mode);
        const request = action(tx.objectStore(STORE));
        tx.oncomplete = () => resolve(request ? request.result : undefined);
        tx.onerror = () => reject(tx.error);
        tx.onabort = () => reject(tx.error);
    }));
}

export async function get(key) {
    try {
        const value = await run('readonly', store => store.get(key));
        return typeof value === 'string' ? value : null;
    } catch (e) {
        console.warn('[data-cache] get failed', key, e);
        return null;
    }
}

export async function set(key, value) {
    try {
        await run('readwrite', store => store.put(value, key));
    } catch (e) {
        console.warn('[data-cache] set failed', key, e);
    }
}

export async function purgeExcept(version) {
    try {
        const prefix = `${version}:`;
        const keys = await run('readonly', store => store.getAllKeys());
        const stale = (keys || []).filter(k => typeof k !== 'string' || !k.startsWith(prefix));
        if (stale.length === 0) return;
        await run('readwrite', store => { stale.forEach(k => store.delete(k)); return null; });
    } catch (e) {
        console.warn('[data-cache] purge failed', e);
    }
}
