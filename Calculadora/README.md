# Calculadora

## Descripci�

Aquest projecte �s una calculadora b�sica desenvolupada en WPF (Windows Presentation Foundation) que permet realitzar operacions matem�tiques senzilles com sumes, restes, multiplicacions i divisions. La calculadora gestiona tamb� operacions encadenades, mostrant resultats en temps real, i inclou un bot� per esborrar l'�ltima operaci� o reiniciar la calculadora.

La calculadora est� dissenyada per ser intu�tiva i f�cil d'usar, amb un disseny senzill i colors distintius per als botons d'operaci� i especials.

## Caracter�stiques

- **Operacions b�siques:** +, -, *, /
- **Resultats en temps real:** Els resultats es mostren immediatament despr�s de pr�mer el bot� "=".
- **Gesti� d'errors:** Manejament de casos d'errors com operacions incorrectes (p. ex., "5 + =") i divisi� per zero.
- **Interf�cie intu�tiva:** Botons arrodonits i colors f�cils de distingir per als operadors i botons especials.

## Requisits

Per executar aquesta aplicaci�, necessites tenir instal�lat el seg�ent:
- Visual Studio amb suport per al desenvolupament en **C#** i **WPF**.
- .NET Framework 4.7.2 o superior.

## Com executar el projecte

1. **Clona el repositori:**

    ```bash
    git clone https://github.com/JoelMargenet/Calculadora.git
    ```

2. **Obre el projecte a Visual Studio.**
   - Obre `Calculadora.sln` al directori del projecte clonado.

3. **Construeix i executa l'aplicaci�:**
   - A Visual Studio, fes clic a "Start" per compilar i executar el projecte.

## �s

1. **Introduir n�meros:** Prem els botons num�rics per afegir n�meros a l'operaci�.
2. **Afegir operadors:** Prem els botons d'operaci� (p. ex., `+`, `-`, `*`, `/`) per afegir operadors a l'operaci�.
3. **Mostrar el resultat:** Prem el bot� "=" per calcular el resultat de l'operaci� actual.
4. **Esborrar operaci�:** Prem el bot� "C" per esborrar l'operaci� actual i reiniciar la calculadora.

## Captures de pantalla

A continuaci� es mostren algunes captures de pantalla que il�lustren l'aplicaci� en �s.

### Pantalla inicial

![Calculadora](images/calculadora_1.png)

### Realitzant una operaci�

![Operaci� en curs](images/calculadora_2.png)

### Resultat mostrat

![Resultat](images/calculadora_3.png)

## Funcionament intern

### M�todes principals

1. **Button_Click (Gestiona els botons num�rics):** Afegeix el n�mero premit al `Display` i a l'operaci� actual.
2. **Operator_Click (Gestiona els botons d'operadors):** Afegeix l'operador premit a l'operaci� actual.
3. **Equals_Click (Calcula el resultat):** Utilitza la classe `DataTable` per calcular l'operaci� introdu�da.
4. **Clear_Click (Esborra l'operaci� actual):** Restableix el `Display` i l'operaci�.

### Gesti� d'errors

L'aplicaci� inclou gesti� d'errors per a casos com:
- Operacions mal formatades (p. ex., "5 + =").
- Divisi� per zero, mostrant un missatge d'error adequat ("Div/0 Error").

## Contribuci�

Si vols contribuir al projecte, segueix aquests passos:
1. Fes un **fork** d'aquest repositori.
2. Crea una nova branca per fer els canvis.
3. Realitza els canvis i crea un **pull request**.

## Llic�ncia

Aquest projecte est� llicenciat sota la llic�ncia MIT - consulta el fitxer [LICENSE](LICENSE) per a m�s detalls.
