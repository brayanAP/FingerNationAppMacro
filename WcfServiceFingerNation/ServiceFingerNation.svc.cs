using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceFingerNation
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceFingerNation" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceFingerNation.svc o ServiceFingerNation.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceFingerNation : IServiceFingerNation
    {
        public List<Alimentos> findAllAlm()
        {
            using (BDFINGERNATIONEntities dbe = new BDFINGERNATIONEntities())
            {
                return dbe.Set<Alimentos>().ToList();

            }
        }//TRAER LISTA ALIMENTOS

        public bool createAlm(List<Alimentos> alimentos)
        {
            using (BDFINGERNATIONEntities dbe = new BDFINGERNATIONEntities())
            {
                bool existsAlm = false;
                var lista = findAllAlm();

                for (int i = 0; i < alimentos.Count; i++)
                {

                    for (int dx = 0; dx < lista.Count; dx++)
                    {
                        if (lista[dx].nombre == alimentos[i].nombre)
                        {
                            existsAlm = true;
                        }
                    }

                    if (!(existsAlm))
                    {
                        try
                        {
                            Alimentos inv = new Alimentos
                            {
                                id = alimentos[i].id,
                                nombre = alimentos[i].nombre,
                                calorias = alimentos[i].calorias,
                                marca = alimentos[i].marca,
                                cantidad = alimentos[i].cantidad,
                                unidadmedida = alimentos[i].unidadmedida,
                                carbohidratos = alimentos[i].carbohidratos,
                                fibra = alimentos[i].fibra,
                                azucar = alimentos[i].azucar,
                                proteinas = alimentos[i].proteinas,
                                grasas = alimentos[i].grasas,
                                monoinsaturadas = alimentos[i].monoinsaturadas,
                                poliinsaturadas = alimentos[i].poliinsaturadas,
                                saturadas = alimentos[i].saturadas,
                                sodio = alimentos[i].sodio
                            };
                            dbe.Alimentos.Add(inv);
                            dbe.SaveChanges();

                        }
                        catch
                        {

                        }
                    }
                    else
                    {
                        existsAlm = false;
                    }
                }
                return true;

            };
        }//GUARDAR ALIMENTO

        public bool editAlm(Alimentos alimentos)
        {
            using (BDFINGERNATIONEntities dbe = new BDFINGERNATIONEntities())
            {
                try
                {
                    Alimentos inv = dbe.Alimentos.Single(i => i.nombre == alimentos.nombre);
                    inv.id = alimentos.id;
                    inv.nombre = alimentos.nombre;
                    inv.calorias = alimentos.calorias;
                    inv.marca = alimentos.marca;
                    inv.cantidad = alimentos.cantidad;
                    inv.unidadmedida = alimentos.unidadmedida;
                    inv.carbohidratos = alimentos.carbohidratos;
                    inv.fibra = alimentos.fibra;
                    inv.azucar = alimentos.azucar;
                    inv.proteinas = alimentos.proteinas;
                    inv.grasas = alimentos.grasas;
                    inv.monoinsaturadas = alimentos.monoinsaturadas;
                    inv.poliinsaturadas = alimentos.poliinsaturadas;
                    inv.saturadas = alimentos.saturadas;
                    inv.sodio = alimentos.sodio;
                    return true;
                }
                catch
                {
                    return false;
                }
            };
        }//EDITAR ALIMENTO

        public bool deleteAlm(Alimentos alimentos)
        {
            using (BDFINGERNATIONEntities dbe = new BDFINGERNATIONEntities())
            {
                try
                {
                    Alimentos inv = dbe.Alimentos.Single(i => i.nombre == alimentos.nombre);
                    dbe.Alimentos.Remove(inv);
                    dbe.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            };
        }//ELIMINAR ALIMENTO

        public Alimentos findAlm(string nombre)
        {
            using (BDFINGERNATIONEntities dbe = new BDFINGERNATIONEntities())
            {
                var query = (from p in dbe.Alimentos
                             where p.nombre == nombre
                             select p);
                var alimentos = query.First();
                return alimentos;
            }
        }//TRAER ALIMENTO UNICO
    }
}
