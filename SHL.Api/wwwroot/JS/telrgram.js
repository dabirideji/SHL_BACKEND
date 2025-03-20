const b = {
  test: location.search.indexOf("test=1") > 0,
  debug: location.search.indexOf("debug=1") > 0,
  http: !1,
  ssl: !0,
  asServiceWorker: !1,
  transport: "websocket",
  noSharedWorker: location.search.indexOf("noSharedWorker=1") > 0,
  multipleTransports: !0,
};
(b.http = location.search.indexOf("http=1") > 0) && (b.multipleTransports = !1);
b.multipleTransports && (b.http = !0);
b.http && (b.transport = "https");
const Z = b.debug,
  De = typeof window < "u" ? window : self,
  se = De,
  P = typeof window < "u" ? window : self,
  F = navigator ? navigator.userAgent : null;
navigator.userAgent.search(/OS X|iPhone|iPad|iOS/i);
navigator.userAgent.toLowerCase().indexOf("android");
(() => {
  try {
    return +navigator.userAgent.match(/Chrom(?:e|ium)\/(.+?)(?:\s|\.)/)[1];
  } catch {}
})();
const ce =
    "safari" in P ||
    !!(
      F &&
      (/\b(iPad|iPhone|iPod)\b/.test(F) ||
        (F.match("Safari") && !F.match("Chrome")))
    ),
  le = navigator.userAgent.toLowerCase().indexOf("firefox") > -1;
(navigator.maxTouchPoints === void 0 || navigator.maxTouchPoints > 0) &&
  navigator.userAgent.search(
    /iOS|iPhone OS|Android|BlackBerry|BB10|Series ?[64]0|J2ME|MIDP|opera mini|opera mobi|mobi.+Gecko|Windows Phone/i
  ) != -1;
const R =
    typeof ServiceWorkerGlobalScope < "u" &&
    self instanceof ServiceWorkerGlobalScope,
  j = typeof WorkerGlobalScope < "u" && self instanceof WorkerGlobalScope && !R,
  Me = j || R,
  he = () =>
    self.clients.matchAll({
      includeUncontrolled: !1,
      type: "window",
    }),
  de = (t, ...e) => {
    try {
      t.postMessage(...e);
    } catch (s) {
      console.error("[worker] postMessage error:", s, e);
    }
  },
  ue = (t, ...e) => {
    he().then((s) => {
      s.length &&
        s.slice(t ? 0 : -1).forEach((n) => {
          de(n, ...e);
        });
    });
  },
  fe = (...t) => {
    de(self, ...t);
  },
  ge = () => {};
R && ue.bind(null, !1);
R && ue.bind(null, !0);
const Oe = Date.now();
function ne() {
  return "[" + ((Date.now() - Oe) / 1e3).toFixed(3) + "]";
}
var I = ((t) => (
  (t[(t.None = 0)] = "None"),
  (t[(t.Error = 1)] = "Error"),
  (t[(t.Warn = 2)] = "Warn"),
  (t[(t.Log = 4)] = "Log"),
  (t[(t.Debug = 8)] = "Debug"),
  t
))(I || {});
const xe = [0, 1, 2, 4, 8],
  Re = ce || le,
  Le = !Re,
  ie = {
    reset: "\x1B[0m",
    bright: "\x1B[1m",
    dim: "\x1B[2m",
    underscore: "\x1B[4m",
    blink: "\x1B[5m",
    reverse: "\x1B[7m",
    hidden: "\x1B[8m",
    fg: {
      black: "\x1B[30m",
      red: "\x1B[31m",
      green: "\x1B[32m",
      yellow: "\x1B[33m",
      blue: "\x1B[34m",
      magenta: "\x1B[35m",
      cyan: "\x1B[36m",
      white: "\x1B[37m",
    },
    bg: {
      black: "\x1B[40m",
      red: "\x1B[41m",
      green: "\x1B[42m",
      yellow: "\x1B[43m",
      blue: "\x1B[44m",
      magenta: "\x1B[45m",
      cyan: "\x1B[46m",
      white: "\x1B[47m",
    },
  },
  Ne = [
    ["debug", 8],
    ["info", 4],
    ["warn", 2],
    ["error", 1],
    ["assert", 1],
    ["trace", 4],
    ["group", 4],
    ["groupCollapsed", 4],
    ["groupEnd", 4],
  ];
function L(t, e = 7, s = !1, n = "") {
  let i;
  !Z && !s && (e = 1),
    Le ? n || (R ? (n = ie.fg.yellow) : j && (n = ie.fg.cyan)) : (n = "");
  const r = n;
  n ? (n = `%s ${n}%s`) : (n = "%s");
  const o = function (...a) {
    return e & 4 && console.log(n, ne(), t, ...a);
  };
  return (
    Ne.forEach(([a, c]) => {
      o[a] = function (...l) {
        return e & c && console[a](n, ne(), t, ...l);
      };
    }),
    (o.setPrefix = function (a) {
      (i = a), (t = "[" + a + "]");
    }),
    o.setPrefix(t),
    (o.setLevel = function (a) {
      e = xe.slice(0, a + 1).reduce((c, l) => c | l, 0);
    }),
    (o.bindPrefix = function (a, c = e) {
      return L(`${i}] [${a}`, c, s, r);
    }),
    o
  );
}
function pe(t) {
  return new Promise((e) => {
    setTimeout(e, t);
  });
}
const Fe = self,
  me = "cachedAssets";
function G(t) {
  return t.ok && t.status === 200;
}
function re(t) {
  return Promise.race([t, pe(1e4).then(() => Promise.reject())]);
}
async function We(t) {
  try {
    const e = await re(Fe.caches.open(me)),
      s = await re(
        e.match(t.request, {
          ignoreVary: !0,
        })
      );
    if (s && G(s)) return s;
    const n = {
      Vary: "*",
    };
    let i = await fetch(t.request, {
      headers: n,
    });
    if (G(i)) e.put(t.request, i.clone());
    else if (i.status === 304) {
      const r =
        t.request.url.replace(/\?.+$/, "") + "?" + ((Math.random() * 1e5) | 0);
      (i = await fetch(r, {
        headers: n,
      })),
        G(i) && e.put(t.request, i.clone());
    }
    return i;
  } catch {
    return fetch(t.request);
  }
}
function Be(t, e) {
  return new Promise((s) => {
    const n = new FileReader();
    n.addEventListener("loadend", (i) => {
      s(i.target.result);
    }),
      n[e](t);
  });
}
function Ue(t) {
  return Be(t, "readAsArrayBuffer");
}
function je(t) {
  return Ue(t).then((e) => new Uint8Array(e));
}
function we() {}
const qe = {
  isFulfilled: !1,
  isRejected: !1,
  notify: () => {},
  notifyAll: function (...t) {
    (this.lastNotify = t), this.listeners?.forEach((e) => e(...t));
  },
  addNotifyListener: function (t) {
    this.lastNotify && t(...this.lastNotify),
      (this.listeners ?? (this.listeners = [])).push(t);
  },
  resolve: function (t) {
    this.isFulfilled ||
      this.isRejected ||
      ((this.isFulfilled = !0), this._resolve(t), this.onFinish());
  },
  reject: function (...t) {
    this.isRejected ||
      this.isFulfilled ||
      ((this.isRejected = !0), this._reject(...t), this.onFinish());
  },
  onFinish: function () {
    (this.notify = this.notifyAll = this.lastNotify = null),
      this.listeners && (this.listeners.length = 0),
      this.cancel && (this.cancel = we);
  },
};
function q() {
  let t, e;
  const s = new Promise((n, i) => {
    (t = n), (e = i);
  });
  return Object.assign(s, qe), (s._resolve = t), (s._reject = e), s;
}
self.deferredPromise = q;
function ze(t) {
  const e = t.length,
    s = new Uint8Array(Math.ceil(e / 2));
  let n = 0;
  e % 2 && (s[n++] = parseInt(t.charAt(0), 16));
  for (let i = n; i < e; i += 2) s[n++] = parseInt(t.substr(i, 2), 16);
  return s;
}
function Ge(t, e) {
  const s = t.length;
  if (s !== e.length) return !1;
  for (let n = 0; n < s; ++n) if (t[n] !== e[n]) return !1;
  return !0;
}
function W(t, e) {
  let s = 0,
    n = 0;
  for (let i = 0; i < 4; i++) {
    const r = t[e + i];
    if (((s = (s << 7) + (r & 127)), n++, !(r & 128))) break;
  }
  return [n, s];
}
function $e(t) {
  if (t[0] !== 5) throw new Error("Invalid DecoderSpecificInfo tag");
  const [e, s] = W(t, 1),
    n = 1 + e;
  return t.subarray(n, n + s);
}
function Ve(t) {
  if (t[0] !== 4) throw new Error("Invalid DecoderConfigDescriptor tag");
  const [e, s] = W(t, 1);
  let n = 1 + e;
  return (n += 13), $e(t.subarray(n));
}
function He(t) {
  if (t[0] !== 3) throw new Error("Invalid ES_Descriptor tag");
  const e = new DataView(t.buffer, t.byteOffset, t.byteLength),
    [s, n] = W(t, 1);
  let i = 1 + s;
  i += 2;
  const r = e.getUint8(i);
  i += 1;
  const o = r & 128,
    a = r & 64;
  if ((o && (i += 2), a)) {
    const l = W(t, i);
    i += 1 + l[0] + l[1];
  }
  return {
    decoderConfigDescriptor: Ve(t.subarray(i)),
  };
}
const Ke = [19, 136],
  $ = ze("0327000100041940150000000001f4000000bb750507138856e5a5"),
  Ye = new TextEncoder().encode("esds"),
  Je = new TextEncoder().encode("mp4a");
function oe(t, e, s = t.length) {
  for (let n = s - e.length; n >= 0; n--) {
    let i = !0;
    for (let r = 0; r < e.length; r++)
      if (t[n + r] !== e[r]) {
        i = !1;
        break;
      }
    if (i) return n;
  }
  return -1;
}
function Xe(t) {
  const e = new DataView(t.buffer, t.byteOffset, t.byteLength);
  let s = t.length,
    n = null;
  for (;;) {
    const o = oe(t, Ye, s);
    if (o === -1) break;
    s = o;
    const a = e.getUint32(o - 4);
    if (a < 0 || o + a > t.length) continue;
    const c = oe(t, Je, o);
    c === -1 ||
      o - c > 100 ||
      (n = {
        offset: o + 8,
        size: a - 12,
      });
  }
  if (!n) throw new Error("No ESDS found");
  const i = t.subarray(n.offset, n.offset + n.size),
    r = He(i);
  if (!r) throw new Error("Invalid ESDS");
  if (!Ge(r.decoderConfigDescriptor, Ke)) throw new Error("Not a broken DSCI");
  if (n.size < $.length)
    throw new Error(
      `ESDS Size not enough (expected at least ${$.length}, got ${n.size})`
    );
  t.set($, n.offset);
}
function Qe(t) {
  try {
    return Xe(t), !0;
  } catch {
    return !1;
  }
}
function Ze(t, e, s = !0, n = !0) {
  let i,
    r,
    o,
    a,
    c = !1;
  const l = (h) => {
      const p = o,
        f = a;
      try {
        const g = t.apply(null, h);
        p(g);
      } catch (g) {
        console.error("debounce error", g), f(g);
      }
    },
    u = (...h) => {
      r || (r = new Promise((f, g) => ((o = f), (a = g)))),
        i
          ? (clearTimeout(i),
            (c = !0),
            a(),
            (r = new Promise((f, g) => ((o = f), (a = g)))))
          : s && (l(h), (c = !1));
      const p = P.setTimeout(() => {
        n && (!s || c) && l(h), i === p && ((i = r = o = a = void 0), (c = !1));
      }, e);
      return (i = p), r.catch(we), r;
    };
  return (
    (u.clearTimeout = () => {
      i && (P.clearTimeout(i), a(), (i = r = o = a = void 0), (c = !1));
    }),
    (u.isDebounced = () => !!i),
    u
  );
}
function et(t) {
  return [
    "image/jpeg",
    "image/png",
    "image/gif",
    "image/svg+xml",
    "image/webp",
    "image/bmp",
    "image/avif",
    "image/jxl",
    "video/mp4",
    "video/webm",
    "video/quicktime",
    "audio/ogg",
    "audio/mpeg",
    "audio/mp4",
    "audio/wav",
    "application/json",
    "application/pdf",
  ].indexOf(t) === -1
    ? "application/octet-stream"
    : t;
}
function ke(t, e = "") {
  Array.isArray(t) || (t = [t]);
  const s = et(e);
  return new Blob(t, {
    type: s,
  });
}
class tt {
  constructor(e, s, n) {
    (this.mimeType = e),
      (this.size = s),
      (this.saveFileCallback = n),
      (this.bytes = new Uint8Array(s));
  }
  async write(e, s) {
    const n = s + e.byteLength;
    if (n > this.bytes.byteLength) {
      const i = new Uint8Array(n);
      i.set(this.bytes, 0), (this.bytes = i);
    }
    this.bytes.set(e, s);
  }
  truncate() {
    this.bytes = new Uint8Array();
  }
  trim(e) {
    this.bytes = this.bytes.slice(0, e);
  }
  finalize(e = !0) {
    const s = ke(this.bytes, this.mimeType);
    return e && this.saveFileCallback && this.saveFileCallback(s), s;
  }
  getParts() {
    return this.bytes;
  }
  replaceParts(e) {
    this.bytes = e;
  }
}
const V = {};
function O(t) {
  return (
    V[t] ??
    (V[t] = {
      type: t,
    })
  );
}
const y = class y {
  constructor(e) {
    (this.dbName = e),
      (this.useStorage = !0),
      b.test && (this.dbName += "_test"),
      y.STORAGES.length && (this.useStorage = y.STORAGES[0].useStorage),
      this.openDatabase(),
      y.STORAGES.push(this);
  }
  openDatabase() {
    return (
      this.openDbPromise ?? (this.openDbPromise = caches.open(this.dbName))
    );
  }
  delete(e) {
    return this.timeoutOperation((s) => s.delete("/" + e));
  }
  deleteAll() {
    return caches.delete(this.dbName);
  }
  get(e) {
    return this.timeoutOperation((s) => s.match("/" + e));
  }
  save(e, s) {
    return this.timeoutOperation((n) => n.put("/" + e, s));
  }
  getFile(e, s = "blob") {
    return this.get(e).then((n) => {
      if (!n) throw O("NO_ENTRY_FOUND");
      return n[s]();
    });
  }
  saveFile(e, s) {
    s instanceof Blob || (s = ke(s));
    const n = new Response(s, {
      headers: {
        "Content-Length": "" + s.size,
      },
    });
    return this.save(e, n).then(() => s);
  }
  timeoutOperation(e) {
    return this.useStorage
      ? new Promise(async (s, n) => {
          let i = !1;
          const r = setTimeout(() => {
            n(), (i = !0);
          }, 15e3);
          try {
            const o = await this.openDatabase();
            if (!o)
              throw (
                ((this.useStorage = !1),
                (this.openDbPromise = void 0),
                "no cache?")
              );
            const a = await e(o);
            if (i) return;
            s(a);
          } catch (o) {
            n(o);
          }
          clearTimeout(r);
        })
      : Promise.reject(O("STORAGE_OFFLINE"));
  }
  prepareWriting(e, s, n) {
    return {
      deferred: q(),
      getWriter: () => new tt(n, s, (r) => this.saveFile(e, r).catch(() => r)),
    };
  }
  static toggleStorage(e, s) {
    return Promise.all(
      this.STORAGES.map((n) => {
        if (((n.useStorage = e), !!s && !e)) return n.deleteAll();
      })
    );
  }
};
y.STORAGES = [];
let B = y;
function st(t) {
  return new Promise((e) => {
    setTimeout(() => {
      e(
        new Response("", {
          status: 408,
          statusText: "Request timed out.",
        })
      );
    }, t);
  });
}
const _ = new Map(),
  J = new B("cachedStreamChunks"),
  nt = 86400,
  ve = "Time-Cached",
  it = () =>
    J.timeoutOperation((t) =>
      t.keys().then((e) => {
        const s = new Map(),
          n = (Date.now() / 1e3) | 0;
        for (const r of e) {
          const o = r.url.match(/\/(\d+?)\?/);
          o && !s.has(o[1]) && s.set(o[1], r);
        }
        const i = [];
        for (const [r, o] of s) {
          const a = t.match(o).then((c) => {
            if (+c.headers.get(ve) + nt <= n)
              return (
                d("will delete stream chunk:", r),
                t.delete(o, {
                  ignoreSearch: !0,
                  ignoreVary: !0,
                })
              );
          });
          i.push(a);
        }
        return Promise.all(i);
      })
    );
setInterval(it, 18e5);
setInterval(() => {
  const t = ye();
  for (const [e, s] of _)
    if (e !== t) {
      for (const n in s) s[n].reject();
      _.delete(e);
    }
}, 12e4);
const H = new Map();
class U {
  constructor(e) {
    (this.info = e),
      (this.loadedOffsets = new Set()),
      (this.destroy = () => {
        H.delete(this.id);
      }),
      (this.id = U.getId(e)),
      H.set(this.id, this),
      (this.limitPart = e.size > 75 * 1024 * 1024 ? ct : at),
      (this.destroyDebounced = Ze(this.destroy, 15e4, !1, !0));
  }
  async requestFilePartFromWorker(e, s, n = !1) {
    const i = {
        docId: this.id,
        dcId: this.info.dcId,
        offset: e,
        limit: s,
      },
      r = JSON.stringify(i),
      o = ye();
    let a = _.get(o);
    a || _.set(o, (a = {}));
    let c = a[r];
    if (c) return c.then((u) => u.bytes);
    this.loadedOffsets.add(e),
      (c = a[r] = q()),
      w
        .invoke("requestFilePart", i, void 0, o)
        .then(c.resolve.bind(c), c.reject.bind(c))
        .finally(() => {
          a[r] === c && (delete a[r], Object.keys(a).length || _.delete(o));
        });
    const l = c.then((u) => u.bytes);
    return (
      this.saveChunkToCache(l, e, s),
      !n && this.preloadChunks(e, e + this.limitPart * 15),
      l
    );
  }
  requestFilePartFromCache(e, s, n) {
    const i = this.getChunkKey(e, s);
    return J.getFile(i).then(
      (r) => (n ? new Uint8Array() : je(r)),
      (r) => {
        r.type;
      }
    );
  }
  requestFilePart(e, s, n) {
    return this.requestFilePartFromCache(e, s, n).then(
      (r) => r || this.requestFilePartFromWorker(e, s, n)
    );
  }
  saveChunkToCache(e, s, n) {
    return e.then((i) => {
      const r = this.getChunkKey(s, n),
        o = new Response(i, {
          headers: {
            "Content-Length": "" + i.length,
            "Content-Type": "application/octet-stream",
            [ve]: "" + ((Date.now() / 1e3) | 0),
          },
        });
      return J.save(r, o);
    });
  }
  preloadChunk(e) {
    this.loadedOffsets.has(e) ||
      (this.loadedOffsets.add(e), this.requestFilePart(e, this.limitPart, !0));
  }
  preloadChunks(e, s) {
    if ((s > this.info.size && (s = this.info.size), !e))
      this.preloadChunk(ae(e, this.limitPart));
    else for (; e < s; e += this.limitPart) this.preloadChunk(e);
  }
  requestRange(e) {
    this.destroyDebounced();
    const s = ot(e, this.info.mimeType, this.info.size);
    if (s) return s;
    let [n, i] = e;
    const r = i && i < this.limitPart ? dt(i - n + 1) : this.limitPart,
      o = ae(n, r);
    return (
      i || (i = Math.min(n + r, this.info.size - 1)),
      this.requestFilePart(o, r).then((a) => {
        (n !== o || i !== o + r) && (a = a.slice(n - o, i - o + 1)),
          (this.shouldPatchMp4 === !0 || this.shouldPatchMp4 === o) &&
            Qe(a) &&
            (this.shouldPatchMp4 = o);
        const c = {
          "Accept-Ranges": "bytes",
          "Content-Range": `bytes ${n}-${n + a.byteLength - 1}/${
            this.info.size || "*"
          }`,
          "Content-Length": `${a.byteLength}`,
        };
        return (
          this.info.mimeType && (c["Content-Type"] = this.info.mimeType),
          new Response(a, {
            status: 206,
            statusText: "Partial Content",
            headers: c,
          })
        );
      })
    );
  }
  getChunkKey(e, s) {
    return this.id + "?offset=" + e + "&limit=" + s;
  }
  patchChromiumMp4() {
    this.shouldPatchMp4 = !0;
  }
  static get(e) {
    return H.get(this.getId(e)) ?? new U(e);
  }
  static getId(e) {
    return e.location.id;
  }
}
function rt(t, e, s) {
  const n = ht(t.request.headers.get("Range")),
    i = JSON.parse(decodeURIComponent(e)),
    r = U.get(i);
  s === "_crbug1250841" && r.patchChromiumMp4(),
    t.respondWith(Promise.race([st(45 * 1e3), r.requestRange(n)]));
}
function ot(t, e, s) {
  return t[0] === 0 && t[1] === 1
    ? new Response(new Uint8Array(2).buffer, {
        status: 206,
        statusText: "Partial Content",
        headers: {
          "Accept-Ranges": "bytes",
          "Content-Range": `bytes 0-1/${s || "*"}`,
          "Content-Length": "2",
          "Content-Type": e || "video/mp4",
        },
      })
    : null;
}
const at = 512 * 1024,
  ct = 1024 * 1024,
  lt = 512 * 4;
function ht(t) {
  if (!t) return [0, 0];
  const [, e] = t.split("="),
    s = e.split(", "),
    [n, i] = s[0].split("-");
  return [+n, +i || 0];
}
function ae(t, e = lt) {
  return t - (t % e);
}
function dt(t) {
  return 2 ** Math.ceil(Math.log(t) / Math.log(2));
}
const ut = {
    name: "tweb",
    version: 7,
    stores: [
      {
        name: "session",
      },
      {
        name: "stickerSets",
      },
      {
        name: "users",
      },
      {
        name: "chats",
      },
      {
        name: "dialogs",
      },
      {
        name: "messages",
      },
    ],
  },
  ft = "assets/img/logo_filled_rounded.png",
  gt = "assets/img/logo_plain.svg";
function Se(t, e, s) {
  const n = s && new Set(s),
    i = (c) => Object.keys(c).filter((l) => c[l] !== void 0),
    r = s ? (c) => i(c).filter((l) => !n.has(l)) : i,
    o = typeof t;
  return t && e && o === "object" && o === typeof e
    ? r(t).length === r(e).length && r(t).every((c) => Se(t[c], e[c], s))
    : t === e;
}
function pt(t, e) {
  if (e) for (const s in e) e[s] !== void 0 && (t[s] = e[s]);
  return t;
}
const M = class M {
  constructor(e) {
    pt(this, e),
      b.test && (this.name += "_test"),
      (this.storageIsAvailable = !0),
      (this.log = L(["IDB", e.name].join("-"))),
      this.log("constructor"),
      this.openDatabase(!0),
      M.INSTANCES.push(this);
  }
  isAvailable() {
    return this.storageIsAvailable;
  }
  openDatabase(e = !1) {
    if (this.openDbPromise && !e) return this.openDbPromise;
    const s = (o, a) => {
        const c = Array.from(o.indexNames);
        for (const l of c) o.deleteIndex(l);
        if (a.indexes?.length)
          for (const l of a.indexes)
            o.indexNames.contains(l.indexName) ||
              o.createIndex(l.indexName, l.keyPath, l.objectParameters);
      },
      n = (o, a) => {
        const c = o.createObjectStore(a.name);
        s(c, a);
      };
    try {
      var i = indexedDB.open(this.name, this.version);
      if (!i) return Promise.reject();
    } catch (o) {
      return (
        this.log.error("error opening db", o.message),
        (this.storageIsAvailable = !1),
        Promise.reject(o)
      );
    }
    let r = !1;
    return (
      setTimeout(() => {
        r || i.onerror(O("IDB_CREATE_TIMEOUT"));
      }, 3e3),
      (this.openDbPromise = new Promise((o, a) => {
        (i.onsuccess = (c) => {
          r = !0;
          const l = i.result;
          let u = !1;
          this.log("Opened"),
            (l.onerror = (h) => {
              (this.storageIsAvailable = !1),
                this.log.error(
                  "Error creating/accessing IndexedDB database",
                  h
                ),
                a(h);
            }),
            (l.onclose = (h) => {
              this.log.error("closed:", h), !u && this.openDatabase();
            }),
            (l.onabort = (h) => {
              this.log.error("abort:", h);
              const p = h.target;
              this.openDatabase((u = !0)), p.onerror && p.onerror(h), l.close();
            }),
            (l.onversionchange = (h) => {
              this.log.error("onversionchange, lol?");
            }),
            o((this.db = l));
        }),
          (i.onerror = (c) => {
            (r = !0),
              (this.storageIsAvailable = !1),
              this.log.error("Error creating/accessing IndexedDB database", c),
              a(c);
          }),
          (i.onupgradeneeded = (c) => {
            (r = !0),
              this.log.warn(
                "performing idb upgrade from",
                c.oldVersion,
                "to",
                c.newVersion
              );
            const l = c.target,
              u = l.result;
            this.stores.forEach((h) => {
              if (!u.objectStoreNames.contains(h.name)) n(u, h);
              else {
                const f = l.transaction.objectStore(h.name);
                s(f, h);
              }
            });
          });
      }))
    );
  }
  static create(e) {
    return this.INSTANCES.find((s) => s.name === e.name) ?? new M(e);
  }
  static closeDatabases(e) {
    this.INSTANCES.forEach((s) => {
      if (e && e === s) return;
      const n = s.db;
      n && ((n.onclose = () => {}), n.close());
    });
  }
};
M.INSTANCES = [];
let X = M;
class mt {
  constructor(e, s) {
    (this.storeName = s),
      (this.log = L(["IDB", e.name, s].join("-"))),
      (this.idb = X.create(e));
  }
  delete(e, s) {
    const n = Array.isArray(e);
    return (
      n || (e = [].concat(e)),
      this.getObjectStore(
        "readwrite",
        (i) => {
          const r = e.map((o) => i.delete(o));
          return n ? r : r[0];
        },
        "",
        s
      )
    );
  }
  clear(e) {
    return this.getObjectStore("readwrite", (s) => s.clear(), "", e);
  }
  save(e, s, n) {
    const i = Array.isArray(e);
    return (
      i || ((e = [].concat(e)), (s = [].concat(s))),
      this.getObjectStore(
        "readwrite",
        (r) => {
          const o = e.map((a, c) => r.put(s[c], a));
          return i ? o : o[0];
        },
        "",
        n
      )
    );
  }
  get(e, s) {
    const n = Array.isArray(e);
    if (n) {
      if (!e.length) return Promise.resolve([]);
    } else {
      if (!e) return;
      e = [].concat(e);
    }
    return this.getObjectStore(
      "readonly",
      (i) => {
        const r = e.map((o) => i.get(o));
        return n ? r : r[0];
      },
      "",
      s
    );
  }
  getObjectStore(e, s, n, i = this.storeName) {
    let r;
    return (
      n && ((r = performance.now()), this.log(n + ": start")),
      this.idb.openDatabase().then(
        (o) =>
          new Promise((a, c) => {
            const l = o.transaction([i], e, {
                durability: "relaxed",
              }),
              u = () => {
                clearTimeout(f), c(l.error);
              },
              h = () => {
                clearTimeout(f),
                  n && this.log(n + ": end", performance.now() - r);
                const E = z.map((N) => N.result);
                a(ee ? E : E[0]);
              };
            l.onerror = u;
            const p = e === "readwrite";
            p && (l.oncomplete = () => h());
            const f = setTimeout(() => {
                this.log.error("transaction not finished", l, n);
              }, 1e4),
              g = s(l.objectStore(i)),
              ee = Array.isArray(g),
              z = ee ? g : [].concat(g);
            if (p) return;
            const te = z.length;
            let Ie = te;
            const _e = () => {
              l.error || --Ie || h();
            };
            for (let E = 0; E < te; ++E) {
              const N = z[E];
              (N.onerror = u), (N.onsuccess = _e);
            }
          })
      )
    );
  }
  getAll(e) {
    return this.getObjectStore("readonly", (s) => s.getAll(), "", e);
  }
}
const k = self,
  wt =
    location.protocol +
    "//" +
    location.hostname +
    location.pathname.split("/").slice(0, -1).join("/") +
    "/",
  kt = 11500;
let be = 0,
  Pe = !0;
class vt {
  constructor(e, s, n) {
    (this.defaults = n), (this.cache = {}), (this.storage = new mt(e, s));
  }
  getDefault(e) {
    const s = this.defaults[e];
    return typeof s == "function" ? s() : s;
  }
  get(e) {
    return this.cache.hasOwnProperty(e)
      ? this.cache[e]
      : this.storage
          .get(e)
          .then(
            (n) => n,
            () => {}
          )
          .then((n) =>
            this.cache.hasOwnProperty(e)
              ? this.cache[e]
              : (n ?? (n = this.getDefault(e)), (this.cache[e] = n))
          );
  }
  getCached(e) {
    const s = this.get(e);
    if (s instanceof Promise) throw "no property";
    return s;
  }
  async set(e, s) {
    const n = this.cache[e] ?? this.defaults[e];
    if (!Se(n, s)) {
      this.cache[e] = s;
      try {
        this.storage.save(e, s);
      } catch {}
    }
  }
}
const Te = {
    push_mute_until: 0,
    push_lang: {
      push_message_nopreview: "You have a new message",
      push_action_mute1d: "Mute for 24H",
      push_action_settings: "Settings",
    },
    push_settings: {},
  },
  T = new vt(ut, "session", Te);
for (const t in Te) T.get(t);
k.addEventListener("push", (t) => {
  const e = t.data.json();
  d("push", {
    ...e,
  });
  try {
    const [s, n, i] = [
        T.getCached("push_mute_until"),
        T.getCached("push_settings"),
        T.getCached("push_lang"),
      ],
      r = Date.now();
    if (Ee() && s && r < s)
      throw `supress notification because mute for ${Math.ceil(
        (s - r) / 6e4
      )} min`;
    if (Date.now() - be <= kt && Pe)
      throw "supress notification because some instance is alive";
    const a = Tt(e, n, i);
    t.waitUntil(a);
  } catch (s) {
    d(s);
  }
});
k.addEventListener("notificationclick", (t) => {
  const e = t.notification;
  d("on notification click", e), e.close();
  const s = t.action;
  if (s === "mute1d" && Ee()) {
    d("[SW] mute for 1d"), T.set("push_mute_until", Date.now() + 864e5);
    return;
  }
  const n = e.data;
  if (!n) return;
  const i = k.clients
    .matchAll({
      type: "window",
    })
    .then((r) => {
      (n.action = s), (A = n);
      for (let o = 0; o < r.length; ++o) {
        const a = r[o];
        if ("focus" in a) {
          a.focus(), w.invokeVoid("pushClick", A, a), (A = void 0);
          return;
        }
      }
      if (k.clients.openWindow)
        return Promise.resolve(T.get("push_settings")).then((o) =>
          k.clients.openWindow(o.baseUrl || wt)
        );
    })
    .catch((r) => {
      d.error("Clients.matchAll error", r);
    });
  t.waitUntil(i);
});
k.addEventListener("notificationclose", St);
const Q = new Set();
let A;
function St(t) {
  bt(t.notification);
}
function bt(t) {
  Q.delete(t);
}
function Pt(t) {
  for (const s of Q)
    try {
      if (t && s.tag !== t) continue;
      s.close(), Q.delete(s);
    } catch {}
  let e;
  return (
    "getNotifications" in k.registration
      ? (e = k.registration
          .getNotifications({
            tag: t,
          })
          .then((s) => {
            for (let n = 0, i = s.length; n < i; ++n)
              try {
                s[n].close();
              } catch {}
          })
          .catch((s) => {
            d.error("Offline register SW error", s);
          }))
      : (e = Promise.resolve()),
    e
  );
}
function Ee() {
  return le;
}
function Tt(t, e, s) {
  let n = t.title || "Telegram",
    i = t.description || "",
    r;
  t.custom &&
    (t.custom.channel_id
      ? (r = "" + -t.custom.channel_id)
      : t.custom.chat_id
      ? (r = "" + -t.custom.chat_id)
      : (r = t.custom.from_id || "")),
    (t.custom.peerId = "" + r);
  let o = "peer" + r;
  const a = r + "_" + t.custom.msg_id;
  if (x.has(a)) {
    const h = "ignoring push";
    throw (d.warn(h, t), x.delete(a), h);
  }
  e?.nopreview &&
    ((n = "Telegram"), (i = s.push_message_nopreview), (o = "unknown_peer"));
  const c = [
      {
        action: "mute1d",
        title: s.push_action_mute1d,
      },
    ],
    l = {
      body: i,
      icon: ft,
      tag: o,
      data: t,
      actions: c,
      badge: gt,
      silent: t.custom.silent === "1",
    };
  return (
    d("show notify", n, i, t, l),
    k.registration.showNotification(n, l).catch((h) => {
      d.error("Show notification promise", h);
    })
  );
}
function Et(t, e) {
  (be = Date.now()),
    (Pe = t.localNotifications),
    A && e && (w.invokeVoid("pushClick", A, e), (A = void 0)),
    t.lang && T.set("push_lang", t.lang),
    t.settings && T.set("push_settings", t.settings);
}
const x = new Map();
function yt(t) {
  x.set(t, Date.now());
}
setInterval(() => {
  const t = Date.now();
  x.forEach((e, s) => {
    t - e > 3e4 && x.delete(s);
  });
}, 30 * 6e4);
const At = ((Date.now() % Math.random()) * 1e8) | 0;
function K(t, e) {
  const s = t.indexOf(e);
  return (s === -1 ? void 0 : t.splice(s, 1))?.[0];
}
function Ct(t, e) {
  const s = t.findIndex(e);
  return s !== -1 ? t.splice(s, 1)[0] : void 0;
}
class It {
  constructor(e) {
    this._constructor(e);
  }
  _constructor(e) {
    (this.reuseResults = e), (this.listeners = {}), (this.listenerResults = {});
  }
  addEventListener(e, s, n) {
    var i;
    if (
      (((i = this.listeners)[e] ?? (i[e] = [])).push({
        callback: s,
        options: n,
      }),
      this.listenerResults.hasOwnProperty(e) &&
        (s(...this.listenerResults[e]), n?.once))
    ) {
      this.listeners[e].pop();
      return;
    }
  }
  addMultipleEventsListeners(e) {
    for (const s in e) this.addEventListener(s, e[s]);
  }
  removeEventListener(e, s, n) {
    this.listeners[e] && Ct(this.listeners[e], (i) => i.callback === s);
  }
  invokeListenerCallback(e, s, ...n) {
    let i, r;
    try {
      i = s.callback(...n);
    } catch (o) {
      r = o;
    }
    if ((s.options?.once && this.removeEventListener(e, s.callback), r))
      throw r;
    return i;
  }
  _dispatchEvent(e, s, ...n) {
    this.reuseResults && (this.listenerResults[e] = n);
    const i = s && [],
      r = this.listeners[e];
    return (
      r &&
        r.slice().forEach((a) => {
          if (r.findIndex((u) => u.callback === a.callback) === -1) return;
          const l = this.invokeListenerCallback(e, a, ...n);
          i && i.push(l);
        }),
      i
    );
  }
  dispatchResultableEvent(e, ...s) {
    return this._dispatchEvent(e, !0, ...s);
  }
  dispatchEvent(e, ...s) {
    this._dispatchEvent(e, !1, ...s);
  }
  cleanup() {
    (this.listeners = {}), (this.listenerResults = {});
  }
}
const _t = !0;
class Dt extends It {
  constructor(e) {
    super(!1),
      (this.logSuffix = e),
      (this.onMessage = (s) => {
        const n = s.data,
          i = s.source || s.currentTarget;
        this.processTaskMap[n.type](n, i, s);
      }),
      (this.processResultTask = (s) => {
        const { taskId: n, result: i, error: r } = s.payload,
          o = this.awaiting[n];
        o &&
          (this.debug && this.log.debug("done", o.taskType, i, r),
          "error" in s.payload ? o.reject(r) : o.resolve(i),
          delete this.awaiting[n]);
      }),
      (this.processAckTask = (s) => {
        const n = s.payload,
          i = this.awaiting[n.taskId];
        if (!i) return;
        const r = i.resolve,
          o = {
            cached: n.cached,
            result: n.cached
              ? "result" in n
                ? Promise.resolve(n.result)
                : Promise.reject(n.error)
              : new Promise((a, c) => {
                  (i.resolve = a), (i.reject = c);
                }),
          };
        r(o), n.cached && delete this.awaiting[n.taskId];
      }),
      (this.processPingTask = (s, n, i) => {
        this.pushTask(this.createTask("pong", void 0), i.source);
      }),
      (this.processPongTask = (s, n, i) => {
        const r = this.pingResolves.get(n);
        r && (this.pingResolves.delete(n), r());
      }),
      (this.processCloseTask = (s, n, i) => {
        this.detachPort(n);
      }),
      (this.processBatchTask = (s, n, i) => {
        const r = {
          data: i.data,
          source: i.source,
          currentTarget: i.currentTarget,
        };
        s.payload.forEach((o) => {
          (r.data = o), this.onMessage(r);
        });
      }),
      (this.processLockTask = (s, n, i) => {
        const r = s.payload;
        this.requestedLocks.has(r) ||
          (this.requestedLocks.set(r, n),
          navigator.locks.request(r, () => {
            this.processCloseTask(void 0, n, void 0),
              this.requestedLocks.delete(r);
          }));
      }),
      (this.processInvokeTask = async (s, n, i) => {
        const r = s.id,
          o = s.payload;
        let a, c, l;
        o.void ||
          ((a = {
            taskId: r,
          }),
          (c = this.createTask("result", a))),
          o.withAck &&
            (l = this.createTask("ack", {
              taskId: r,
              cached: !0,
            }));
        let u;
        try {
          const h = this.listeners[o.type];
          if (!h?.length) throw new Error("no listener");
          const p = h[0];
          let f = this.invokeListenerCallback(o.type, p, o.payload, n, i);
          if (o.void) return;
          if (((u = f instanceof Promise), l)) {
            const g = !u;
            if (
              ((l.payload.cached = g),
              g && (l.payload.result = f),
              this.pushTask(l, n),
              g)
            )
              return;
          }
          u && (f = await f), (a.result = f);
        } catch (h) {
          if ((this.log.error("worker task error:", h, s), o.void)) return;
          if (l && l.payload.cached) {
            (l.payload.error = h), this.pushTask(l, n);
            return;
          }
          a.error = h;
        }
        this.pushTask(c, n);
      }),
      (this.listenPorts = []),
      (this.sendPorts = []),
      (this.pingResolves = new Map()),
      (this.taskId = 0),
      (this.awaiting = {}),
      (this.pending = new Map()),
      (this.log = L("MP" + (e ? "-" + e : ""))),
      (this.debug = Z),
      (this.heldLocks = new Map()),
      (this.requestedLocks = new Map()),
      (this.processTaskMap = {
        result: this.processResultTask,
        ack: this.processAckTask,
        invoke: this.processInvokeTask,
        ping: this.processPingTask,
        pong: this.processPongTask,
        close: this.processCloseTask,
        lock: this.processLockTask,
        batch: this.processBatchTask,
      });
  }
  setOnPortDisconnect(e) {
    this.onPortDisconnect = e;
  }
  attachPort(e) {
    this.attachListenPort(e), this.attachSendPort(e);
  }
  attachListenPort(e) {
    this.listenPorts.push(e), e.addEventListener("message", this.onMessage);
  }
  attachSendPort(e) {
    if (
      (this.log.warn("attaching send port"),
      e.start?.(),
      this.sendPorts.push(e),
      typeof window < "u" && _t)
    )
      if ("locks" in navigator) {
        const s = [
          "lock",
          At,
          this.logSuffix || "",
          (Math.random() * 2147483647) | 0,
        ].join("-");
        this.log.warn("created lock", s);
        const n = new Promise((i) =>
          this.heldLocks.set(e, {
            resolve: i,
            id: s,
          })
        ).then(() => this.heldLocks.delete(e));
        navigator.locks.request(s, () => (this.resendLockTask(e), n));
      } else
        window.addEventListener("beforeunload", () => {
          const s = this.createTask("close", void 0);
          this.postMessage(void 0, s);
        });
    this.releasePending();
  }
  resendLockTask(e) {
    const s = this.heldLocks.get(e);
    s && this.pushTask(this.createTask("lock", s.id), e);
  }
  detachPort(e) {
    this.log.warn("disconnecting port"),
      K(this.listenPorts, e),
      K(this.sendPorts, e),
      e.removeEventListener?.("message", this.onMessage),
      e.close?.(),
      this.onPortDisconnect?.(e),
      this.heldLocks.get(e)?.resolve();
    const n = O("PORT_DISCONNECTED");
    for (const i in this.awaiting) {
      const r = this.awaiting[i];
      r.port === e && (r.reject(n), delete this.awaiting[i]);
    }
  }
  postMessage(e, s) {
    (Array.isArray(e) ? e : e ? [e] : this.sendPorts).forEach((i) => {
      i.postMessage(s, s.transfer);
    });
  }
  async releasePending() {
    this.releasingPending ||
      ((this.releasingPending = !0),
      await Promise.resolve(),
      this.debug &&
        this.log.debug("releasing tasks, length:", this.pending.size),
      this.pending.forEach((e, s) => {
        let n = e;
        {
          let r;
          (n = []),
            e.forEach((o) => {
              o.transfer
                ? ((r = void 0), n.push(o))
                : (r || ((r = this.createTask("batch", [])), n.push(r)),
                  r.payload.push(o));
            });
        }
        const i = s ? [s] : this.sendPorts;
        i.length &&
          (n.forEach((r) => {
            try {
              this.postMessage(i, r);
            } catch (o) {
              this.log.error("postMessage error:", o, r, i);
            }
          }),
          this.pending.delete(s));
      }),
      this.debug && this.log.debug("released tasks"),
      (this.releasingPending = !1));
  }
  createTask(e, s, n) {
    return {
      type: e,
      payload: s,
      id: this.taskId++,
      transfer: n,
    };
  }
  createInvokeTask(e, s, n, i, r) {
    return this.createTask(
      "invoke",
      {
        type: e,
        payload: s,
        withAck: n,
        void: i,
      },
      r
    );
  }
  pushTask(e, s) {
    let n = this.pending.get(s);
    n || this.pending.set(s, (n = [])), n.push(e), this.releasePending();
  }
  invokeVoid(e, s, n, i) {
    const r = this.createInvokeTask(e, s, void 0, !0, i);
    this.pushTask(r, n);
  }
  invoke(e, s, n, i, r) {
    this.debug && this.log.debug("start", e, s);
    let o;
    const a = new Promise((c, l) => {
      (o = this.createInvokeTask(e, s, n, void 0, r)),
        (this.awaiting[o.id] = {
          resolve: c,
          reject: l,
          taskType: e,
          port: i,
        }),
        this.pushTask(o, i);
    });
    if (Me) {
      a.finally(() => {
        clearInterval(c);
      });
      const c = P.setInterval(() => {
        this.log.error("task still has no result", o, i);
      }, 6e4);
    }
    return a;
  }
  invokeExceptSource(e, s, n) {
    const i = this.sendPorts.slice();
    K(i, n),
      i.forEach((r) => {
        this.invokeVoid(e, s, r);
      });
  }
}
class Mt extends Dt {
  constructor() {
    super("SERVICE"), se && (se.serviceMessagePort = this);
  }
}
function Ot(t, e, s) {
  const n = (i, r) => {
    t.attachListenPort(i), r && t.attachSendPort(r), e?.(i);
  };
  t.setOnPortDisconnect(s),
    typeof SharedWorkerGlobalScope < "u"
      ? P.addEventListener("connect", (i) => n(i.source, i.source))
      : typeof ServiceWorkerGlobalScope < "u"
      ? n(P, null)
      : n(P, P);
}
const m = new Map(),
  Y = O("UNKNOWN"),
  xt = !1;
self.downloadMap = m;
const Rt = {
  download: (t) => {
    const { id: e } = t;
    if (m.has(e)) return Promise.reject(Y);
    const s = new CountQueuingStrategy({
        highWaterMark: 1,
      }),
      n = q();
    n.then(
      () => {
        setTimeout(() => {
          m.delete(e);
        }, 5e3);
      },
      () => {
        m.delete(e);
      }
    );
    let i;
    const r = new ReadableStream(
        {
          start: (a) => {
            i = a;
          },
          cancel: (a) => {
            n.reject(Y);
          },
        },
        s
      ),
      o = {
        ...t,
        readableStream: r,
        promise: n,
        controller: i,
      };
    return (
      m.set(e, o),
      n.catch(() => {
        throw Y;
      })
    );
  },
  downloadChunk: ({ id: t, chunk: e }) => {
    const s = m.get(t);
    return s ? s.controller.enqueue(e) : Promise.reject();
  },
  downloadFinalize: (t) => {
    const e = m.get(t);
    return e ? (e.promise.resolve(), e.controller.close()) : Promise.reject();
  },
  downloadCancel: (t) => {
    const e = m.get(t);
    if (e) return e.promise.reject(), e.controller.error();
  },
};
function Lt(t) {
  return (
    t.addMultipleEventsListeners(Rt),
    {
      onDownloadFetch: Nt,
      onClosedWindows: Ft,
    }
  );
}
function Nt(t, e) {
  const s = pe(100).then(() => {
    const n = m.get(e);
    if (!n || (n.used && !xt)) return;
    n.used = !0;
    const i = n.readableStream;
    return new Response(i, {
      headers: n.headers,
    });
  });
  t.respondWith(s);
}
function Ft() {
  if (m.size) for (const [t, e] of m) e.controller.error();
}
const D = {};
function Wt(t) {
  return {
    files: t.getAll("files"),
    title: t.get("title"),
    text: t.get("text"),
    url: t.get("url"),
  };
}
async function Bt(t, e) {
  try {
    d("share data", t);
    const s = Wt(t);
    (D[e] ?? (D[e] = [])).push(s);
  } catch (s) {
    d.warn("something wrong with the data", s);
  }
}
function Ut(t) {
  const e = D[t.id];
  e &&
    (delete D[t.id],
    d("releasing share events to client:", t.id, "length:", e.length),
    e.forEach((s) => {
      w.invokeVoid("share", s, t);
    }));
}
function jt(t, e) {
  const s = t.request
    .formData()
    .then((n) => (Bt(n, t.resultingClientId), Response.redirect("..")));
  t.respondWith(s);
}
const d = L("SW", I.Error | I.Debug | I.Log | I.Warn, !0),
  v = self;
let C;
const ye = () => C;
d("init");
const qt = (t) => {
    const e = new MessageChannel();
    w.attachPort((C = e.port1)), w.invokeVoid("port", void 0, t, [e.port2]);
  },
  zt = (t) => {
    !S.size && !C && (d("sending message port for mtproto"), qt(t));
  },
  Ae = (t) => {
    if (
      (d("window connected", t.id, "windows before", S.size),
      t.frameType === "none")
    ) {
      d.warn("maybe a bugged Safari starting window", t.id);
      return;
    }
    d("windows", Array.from(S)),
      w.invokeVoid("hello", void 0, t),
      zt(t),
      S.set(t.id, t),
      Ut(t);
  },
  w = new Mt();
w.addMultipleEventsListeners({
  notificationsClear: Pt,
  toggleStorages: ({ enabled: t, clearWrite: e }) => {
    B.toggleStorage(t, e);
  },
  pushPing: (t, e) => {
    Et(t, e);
  },
  hello: (t, e) => {
    Ae(e);
  },
  shownNotification: yt,
});
const { onDownloadFetch: Gt, onClosedWindows: $t } = Lt(w);
he().then((t) => {
  d(`got ${t.length} windows from the start`),
    t.forEach((e) => {
      Ae(e);
    });
});
const S = new Map();
self.connectedWindows = S;
Ot(w, void 0, (t) => {
  if (
    (d("something has disconnected", t),
    !(t instanceof WindowClient) || !S.has(t.id))
  ) {
    d.warn("it is not a window");
    return;
  }
  S.delete(t.id),
    d("window disconnected, left", S.size),
    S.size ||
      (d.warn("no windows left"), C && (w.detachPort(C), (C = void 0)), $t());
});
const Vt = (t) => {
    if (
      !ce &&
      t.request.url.indexOf(location.origin + "/") === 0 &&
      t.request.url.match(
        /\.(js|css|jpe?g|json|wasm|png|mp3|svg|tgs|ico|woff2?|ttf|webmanifest?)(?:\?.*)?$/
      )
    )
      return t.respondWith(We(t));
    try {
      const [e, s] = t.request.url.split("/").slice(-2),
        [n, i] = s.split("?");
      switch (e) {
        case "stream": {
          rt(t, n, i);
          break;
        }
        case "download": {
          Gt(t, n);
          break;
        }
        case "share": {
          jt(t, n);
          break;
        }
        case "ping": {
          t.respondWith(new Response("pong"));
          break;
        }
      }
    } catch (e) {
      d.error("fetch error", e),
        t.respondWith(
          new Response("", {
            status: 500,
            statusText: "Internal Server Error",
            headers: {
              "Cache-Control": "no-cache",
            },
          })
        );
    }
  },
  Ce = () => {
    v.onfetch = Vt;
  };
v.addEventListener("install", (t) => {
  d("installing"),
    t.waitUntil(v.skipWaiting().then(() => d("skipped waiting")));
});
v.addEventListener("activate", (t) => {
  d("activating", v),
    t.waitUntil(v.caches.delete(me).then(() => d("cleared assets cache"))),
    t.waitUntil(v.clients.claim().then(() => d("claimed clients")));
});
v.onoffline = v.ononline = Ce;
Ce();
//# sourceMappingURL=sw-ANPVSkpv.js.map
