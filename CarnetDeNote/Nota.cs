namespace CarnetDeNote;

<<<<<<< HEAD
public abstract class Nota<T> where T: IComparable
{
    protected T nota { get; set; }
    public Nota(T nota)
=======
public abstract class Nota
{
    public float nota { get; private set; }
    public Nota(float nota)
>>>>>>> c16edad8762288de11b4aa8d0d5b7488fd9812dc
    {
        this.nota = nota;
    }

<<<<<<< HEAD
    protected virtual bool Validare(T nota)
    {
        return (nota.CompareTo(1)>=0) && (nota.CompareTo(10)<=0);
=======
    protected virtual bool Validare(float nota)
    {
        return nota>=1 && nota<=10;
>>>>>>> c16edad8762288de11b4aa8d0d5b7488fd9812dc
    }
}