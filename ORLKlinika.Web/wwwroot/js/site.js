document.addEventListener("DOMContentLoaded", function () {
    // Postavljanje max datuma na današnji
    const datumInput = document.getElementById("DatumRodjenja");
    if (datumInput) {
        let today = new Date().toISOString().split('T')[0];
        datumInput.setAttribute("max", today);
    }

    // Brisanje pacijenta
    $(".delete-form").on("submit", function (e) {
        if (!confirm("Da li ste sigurni da želite da obrišete pacijenta?")) {
            e.preventDefault();
        }
    });

    // Filtar pacijenata po godinama
    $("#chkDete, #chkOdrasli, #chkStari").on("change", function () {
        let dete = $("#chkDete").is(":checked");
        let odrasli = $("#chkOdrasli").is(":checked");
        let stari = $("#chkStari").is(":checked");

        $("#pacijentiTabela tbody tr").each(function () {
            let godine = parseInt($(this).data("godine"));
            let prikazi = (dete && godine < 18) || (odrasli && godine >= 18 && godine < 60) || (stari && godine >= 60);
            $(this).toggle(prikazi);
        });
    }).trigger("change");

    // Prikazivanje/sakrivanje termina
    $("#toggleProsli").on("click", function () {
        let prikaziProsle = $(this).data("prikazi") || false;
        prikaziProsle = !prikaziProsle;
        $(this).data("prikazi", prikaziProsle);

        if (prikaziProsle) {
            $(".buduci-termin").hide();
            $(".prosli-termin").show();
            $(this).text("Prikaži sve termine");
        } else {
            $(".buduci-termin, .prosli-termin").show();
            $(this).text("Prikaži prošle termine");
        }
    });

    // Validacija termina
    const forma = document.getElementById("terminForma");
    const greska = document.getElementById("errorMessage");
    const lekarSelect = document.getElementById("LekarId") || document.getElementById("LekarSelect");
    const datumTermina = document.getElementById("DatumTermina");
    if (forma && greska && lekarSelect && datumTermina && typeof zauzetiTermini !== "undefined") {
        forma.addEventListener("submit", function (e) {
            greska.classList.add("d-none");
            greska.innerText = "";

            const izabraniLekar = parseInt(lekarSelect.value);
            const unetiDatum = new Date(datumTermina.value);

            const postojiKonflikt = zauzetiTermini.some(t =>
                t.lekarId === izabraniLekar &&
                Math.abs(new Date(t.datum) - unetiDatum) < 60 * 60 * 1000
            );

            if (postojiKonflikt) {
                e.preventDefault();
                greska.innerText = "Lekar već ima zakazan termin u ovom vremenskom periodu. Potrebno je barem 1 sat razmaka.";
                greska.classList.remove("d-none");
            }
        });
    }

    // Dinamičko filtriranje lekara po usluzi
    const uslugaSelect = document.getElementById("UslugaSelect");
    if (uslugaSelect && lekarSelect && typeof uslugeSubspec !== "undefined") {
        const sviLekari = Array.from(lekarSelect.options).map(opt => ({
            id: opt.value,
            text: opt.text,
            subspecijalizacija: opt.getAttribute("data-sub")
        }));

        uslugaSelect.addEventListener("change", function () {
            const selectedUslugaId = parseInt(this.value);
            const sub = uslugeSubspec.find(u => u.id === selectedUslugaId)?.sub;

            lekarSelect.innerHTML = "";

            sviLekari.filter(l => l.subspecijalizacija === sub).forEach(l => {
                const opt = document.createElement("option");
                opt.value = l.id;
                opt.text = l.text;
                opt.setAttribute("data-sub", l.subspecijalizacija);
                lekarSelect.appendChild(opt);
            });
        });
    }
});
