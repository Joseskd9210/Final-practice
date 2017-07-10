private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
			
			objetoMiClase.conectar();
           
               
            int  idimagenasociada,idreceta,idvinos,idutensilios,idingrediente ;  
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Archivos xml(*.xml)|*.xml";
            open.Title = "XML";
            if (open.ShowDialog() == DialogResult.OK)
            {
                XmlDocument xDoc = new XmlDocument();

                //La ruta del documento XML permite rutas relativas 
                //respecto del ejecutable!

                
                xDoc.Load(open.FileName);

                XmlNodeList recetas = xDoc.GetElementsByTagName("recetas");

                XmlNodeList lista =
                    ((XmlElement)recetas[0]).GetElementsByTagName("receta");

                foreach (XmlElement nodo in lista)
                {
					
					//Compruebo las recetas
                    XmlNodeList nDificultad =
                    nodo.GetElementsByTagName("dificultad");

                    XmlNodeList nTiempo =
                    nodo.GetElementsByTagName("tiempo");

                    XmlNodeList nTipoPlato =
                    nodo.GetElementsByTagName("tipoPlato");
					
					XmlNodeList nTiempo =
                    nodo.GetElementsByTagName("tiempo");
					
					XmlNodeList nDescripcion =
                    nodo.GetElementsByTagName("Descripcion");
					
					XmlNodeList nObservacion =
                    nodo.GetElementsByTagName("Observacion");
					
					XmlNodeList nTitulo =
                    nodo.GetElementsByTagName("titulo");
					
					XmlNodeList nImagen =
                    nodo.GetElementsByTagName("Imagen");
					//Compruebo receta
					
					SqlDataReader midatareader = objetoMiClase.leerbasedatos("*", "receta", "where nombre='" + nNombre[0].InnerText + "'");
					if (midatareader.HasRow()==NULL){
						if (objetoMiClase.insertarbasedatos("receta (titulo, dificultad, tiempo, tipo_plato, descripcion, observacion )", "'" + nTitulo[0].InnerText + "','" + nDificultad[0].InnerText + "','" + nTiempo[0].InnerText + "','" + nTipoPlato[0].InnerText + "','" + nDescripcion[0].InnerText + "','" + nObservacion[0].InnerText + "'")) { 
							MessageBox.Show("Insertado correctamente 1");
							SqlDataReader midatareader1 = objetoMiClase.leerbasedatos("*", "receta", "where titulo='" + nTitulo[0].InnerText + "'");
							while (midatareader1.Read())
							{
								idreceta = midatareader1.GetInt32(0);
							}
							midatareader1.close();
							if (objetoMiClase.insertarbasedatos("imagenes (titulo,ruta)", "'" + nImagen[0].InnerText + "','" + nImagen[0].InnerText + "'")) { MessageBox.Show("Insertado correctamente imagen"); }
							SqlDataReader midatareader2 = objetoMiClase.leerbasedatos("*", "imagenes", "where titulo='" + nImagen[0].InnerText + "'");
							while (midatareader2.Read())
							{
								idimagenasociada = midatareader2.GetInt32(0);
							}
							midatareader2.Close(); 
							//relacionamos imagen
							if (objetoMiClase.insertarbasedatos("esdereceta (id_imagen,id_receta)", idimagenasociada + "," + idreceta)) {
								MessageBox.Show("Insertado correctamente imagen receta"); 
								}
						}
					}
					midatareader.close();
				//Vinos 
					XmlNodeList vinos = xDoc.GetElementsByTagName("vinos");

					XmlNodeList listaVinos =
                    ((XmlElement)vinos[0]).GetElementsByTagName("vino");
					foreach (XmlElement nodoVinos in listaVinos)
					{
						XmlNodeList nNombre =
						nodo1.GetElementsByTagName("nombre");

						XmlNodeList nDenominacion =
						nodo.GetElementsByTagName("denominacion");
						SqlDataReader midatareader = objetoMiClase.leerbasedatos("*", "vinos", "where nombre='" + nNombre[0].InnerText + "'");
						if (midatareader.HasRow()==NULL){
							
							if (objetoMiClase.insertarbasedatos("vinos (nombre, denominacion)", "'" + nNombre[0].InnerText + "','" + nDenominacion + "'"))
							{
								MessageBox.Show("Insertado correctamente 1");
								SqlDataReader midatareader1 = objetoMiClase.leerbasedatos("*", "vinos", "where nombre='" + nTitulo[0].InnerText + "'");
						
								while (midatareader.Read())
								{
											idvinos = midatareader1.GetInt32(0);
								}
								midatareader1.close();
								if (objetoMiClase.insertarbasedatos("recomienda (id_vino,id_receta)",  idvinos + "," + idreceta)) { MessageBox.Show("Insertado correctamente vino"); }								
							}
							
						}
						else{
							SqlDataReader midatareader1 = objetoMiClase.leerbasedatos("*", "vinos", "where nombre='" + nTitulo[0].InnerText + "'");
                
								while (midatareader.Read())
								{
									idvinos = midatareader1.GetInt32(0);
								}
								midatareader1.close();
						if (objetoMiClase.insertarbasedatos("recomienda (id_vino,id_receta)",  idvinos + "," + idreceta)) { MessageBox.Show("Insertado correctamente vino"); }
							
						}
						midatareader.close();
					}
					
					//Utensilios
					XmlNodeList utensilios = xDoc.GetElementsByTagName("utensilios");

					XmlNodeList listaUten =
					((XmlElement)utensilios[0]).GetElementsByTagName("utensilio");
					foreach (XmlElement nodoUten in listaUten)
					{
						XmlNodeList nNombre =
						nodoUten.GetElementsByTagName("nombre");
						SqlDataReader midatareader = objetoMiClase.leerbasedatos("*", "utensilios", "where nombre='" + nNombre[0].InnerText + "'");
						if (midatareader.HasRow()==NULL){
							if (objetoMiClase.insertarbasedatos("utensilios (nombre)", "'" + nNombre[0].InnerText + "'"))
							{
							MessageBox.Show("Insertado correctamente 1");
							SqlDataReader midatareader1 = objetoMiClase.leerbasedatos("*", "utensilios", "where nombre='" + nTitulo[0].InnerText + "'");
                
								while (midatareader1.Read())
								{
									idutensilios = midatareader.GetInt32(0);
								}
								midatareader1.close();
							if (objetoMiClase.insertarbasedatos("usa (Id_receta, id_utensilios)", idreceta + "," + idutensilios)) { MessageBox.Show("Insertado correctamente usa"); }
							}
						midatareader.close();
						}
							else {
								SqlDataReader midatareader = objetoMiClase.leerbasedatos("*", "utensilios", "where nombre='" + nTitulo[0].InnerText + "'");
								while (midatareader.Read())
								{
									idutensilios = midatareader.GetInt32(0);
								}
								if (objetoMiClase.insertarbasedatos("usa (Id_receta, id_utensilios)", idreceta + "," + idutensilios)) { MessageBox.Show("Insertado correctamente usa"); }
								midatareader.close();
							}						
					}
					
					//Ingredientes
					XmlNodeList ingredientes = xDoc.GetElementsByTagName("ingredientes");

					XmlNodeList listaIngre =
						((XmlElement)ingredientes[0]).GetElementsByTagName("ingrediente");
					foreach (XmlElement nodoIngre in listaIngre)
					{
						 XmlNodeList nNombre =
						nodoIngre.GetElementsByTagName("nombre");

						XmlNodeList nCantidad =
						nodoIngre.GetElementsByTagName("cantidad");
						
						XmlNodeList nCostes =
						nodoIngre.GetElementsByTagName("coste");
						
						XmlNodeList nImagen =
						nodoIngre.GetElementsByTagName("coste");
						SqlDataReader midatareader = objetoMiClase.leerbasedatos("*", "ingredientes", "where nombre='" + nNombre[0].InnerText + "'");	
						if (midatareader.HasRow()==NULL){
							
								if (objetoMiClase.insertarbasedatos("ingredientes (nombre, cantidad, costes)", "'" + nNombre[0].InnerText + "','" + nCantidad[0].InnerText + "','" + nCostes[0].InnerText + "'"))
							{
								MessageBox.Show("Insertado correctamente 1");
							}
							SqlDataReader midatareader1 = objetoMiClase.leerbasedatos("*", "ingredientes", "where nombre='" + nNombre[0].InnerText + "'");

							while (midatareader1.Read())
							{
								idingrediente = midatareader1.GetInt32(0);
							}
							midatareader1.Close();
							//metemos imagen
								if (objetoMiClase.insertarbasedatos("imagenes (titulo,ruta)", "'" + nImagen[0].InnerText + "','" + nImagen[0].InnerText + "'")) { 
									MessageBox.Show("Insertado correctamente imagen"); 
								}	
								SqlDataReader midatareader2 = objetoMiClase.leerbasedatos("*", "imagenes", "where titulo='" + nNombre[0].InnerText + "'");
								while (midatareader2.Read()){
								idimagenasociada = midatareader2.GetInt32(0);
								}
								midatareader2.Close();
								//relacionamos imagen
								if (objetoMiClase.insertarbasedatos("esdeingrediente (id_imagen,id_ingrediente)", idimagenasociada + "," + idingrediente)) {
									MessageBox.Show("Insertado correctamente imagen ingrediente"); 
								}
								if (objetoMiClase.insertarbasedatos("tiene (Id_receta, id_ingrediente, cantidad)", idreceta + "," + idingrediente + "," + nCantidad[0].InnerText)) { 
									MessageBox.Show("Insertado correctamente tiene"); 
								}
						}
						midatareader.close();
						else {
							
							SqlDataReader midatareader = objetoMiClase.leerbasedatos("*", "ingredientes", "where nombre='" + nNombre[0].InnerText + "'");
							while (midatareader.Read()){
							idingrediente = midatareader.GetInt32(0);
							}
							midatareader.Close();
						//metemos imagen
                
							if (objetoMiClase.insertarbasedatos("imagenes (titulo,ruta)", "'" + nImagen[0].InnerText + "','" + nImagen[0].InnerText + "'")) { MessageBox.Show("Insertado correctamente imagen"); }
							SqlDataReader midatareader2 = objetoMiClase.leerbasedatos("*", "imagenes", "where titulo='" + nNombre[0].InnerText + "'");

							while (midatareader2.Read()){
							idimagenasociada = midatareader2.GetInt32(0);
							}
							midatareader2.Close();
							//relacionamos imagen
							if (objetoMiClase.insertarbasedatos("esdeingrediente (id_imagen,id_ingrediente)", idimagenasociada + "," + idingrediente)) { 
								MessageBox.Show("Insertado correctamente imagen ingrediente"); 
							}
							if (objetoMiClase.insertarbasedatos("tiene (Id_receta, id_ingrediente, cantidad)", idreceta + "," + idingrediente + "," + nCantidad[0].InnerText)) { 
								MessageBox.Show("Insertado correctamente tiene"); 
							}
						}
									
					}	
					//Alergenos
					XmlNodeList alergenos = xDoc.GetElementsByTagName("alergenos");

					XmlNodeList listaAler =
                    ((XmlElement)alergenos[0]).GetElementsByTagName("alergeno");
					foreach (XmlElement nodoAler in listaAler)
					{

						XmlNodeList nNombre =
						nodoAler.GetElementsByTagName("nombre");

						XmlNodeList nTipo =
						nodoAler.GetElementsByTagName("tipo");
					   SqlDataReader midatareader = objetoMiClase.leerbasedatos("*", "alergenos", "where nombre='" + nNombre[0].InnerText + "'"); 
					   if (midatareader.HasRow()==NULL){
							if (objetoMiClase.insertarbasedatos("alergenos (nombre, tipo)", "'" + nNombre[0].InnerText + "','" + nTipo[0].InnerText + "'")){
								MessageBox.Show("Insertado correctamente 1");
							}					
						}
					   
					}
					if (objetoMiClase.insertarbasedatos("receta (titulo, dificultad, tiempo, tipo_plato, descripcion, observacion )", "'" + nTitulo[0].InnerText + "','" + nDificultad[0].InnerText + "','" + nTiempo[0].InnerText + "','" + nTipoPlato[0].InnerText + "','" + nDescripcion[0].InnerText + "','" + nObservacion[0].InnerText + "'")) { 
						MessageBox.Show("Insertado correctamente 1");

						SqlDataReader midatareader = objetoMiClase.leerbasedatos("*", "receta", "where titulo='" + nTitulo[0].InnerText + "'");
						
						while (midatareader.Read())
						{
							idreceta = midatareader.GetInt32(0);
						}
						if (objetoMiClase.insertarbasedatos("imagenes (titulo,ruta)", "'" + nImagen[0].InnerText + "','" + nImagen[0].InnerText + "'")) { MessageBox.Show("Insertado correctamente imagen"); }
					
						SqlDataReader midatareader2 = objetoMiClase.leerbasedatos("*", "imagenes", "where titulo='" + nImagen[0].InnerText + "'");
						
						while (midatareader2.Read())
						{
							idimagenasociada = midatareader2.GetInt32(0);
						}
						midatareader2.Close(); 
					//relacionamos imagen
					if (objetoMiClase.insertarbasedatos("esdereceta (id_imagen,id_receta)", idimagenasociada + "," + idreceta)) {
						MessageBox.Show("Insertado correctamente imagen receta"); 
						}    
					}
					midatareader.Close();
					
				}
				
			}	
		}		
				