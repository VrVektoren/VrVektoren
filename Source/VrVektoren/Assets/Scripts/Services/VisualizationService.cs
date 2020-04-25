using System;
using UnityEngine;
using VrVektoren.Core;

namespace VrVektoren.Services
{
    public class VisualizationService: ScriptableObject
    {
        private static VisualizationService visualizationService;

        private static VisualizationService Instance
        {
            get
            {
                if (visualizationService == null)
                {
                    visualizationService = FindObjectOfType<VisualizationService>();

                    if (visualizationService == null)
                    {
                        visualizationService = ScriptableObject.CreateInstance<VisualizationService>();
                    }
                }

                return visualizationService;
            }
        }

        public static Vizualization[] GetVisualizations()
        {
            return Instance.visualizations;
        }
        
        private readonly Vizualization[] visualizations;

        public VisualizationService()
        {
            this.visualizations = new Vizualization[]
            {
                this.GetVisualizationAddition(),
                this.GetVisualizationCommutativeRule(),
                this.GetVisualizationSubtraction(),
                this.GetVisualizationCube(),
                this.GetVisualizationScalarProduct()
            };
        }
        
        private Vizualization GetVisualizationAddition()
        {
            var vectors = new Vector[]
                {
                    new Vector(Color.blue),
                    new Vector(Color.yellow),
                    new Vector(Color.green),
                    new Vector(Color.red)
                };

            var visualization = new Vizualization(
                1,
                "Vektoraddition",
                vectors,
                new Step[]
                {
                    new Step(
                        new Tuple<Vector, VectorPosition>[]
                        {
                            new Tuple<Vector, VectorPosition>(
                                vectors[0],
                                new VectorPosition(
                                    true,
                                    new Point(-5, 1, 0),
                                    new EulerAngle(-30, 30, 0),
                                    4.5)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[1],
                                new VectorPosition(
                                    true,
                                    new Point(0, 1, 0),
                                    new EulerAngle(-45, 230, 0),
                                    6)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[2],
                                new VectorPosition(
                                    true,
                                    new Point(3, 1, 0),
                                    new EulerAngle(0, 130, 0),
                                    3)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[3],
                                new VectorPosition(
                                    false,
                                    new Point(0, 1, 0),
                                    new EulerAngle(-75.3, 142.3, 0),
                                    6.7)),
                        },
                        new Tuple<Angle, bool>[]{}),
                    new Step(
                        new Tuple<Vector, VectorPosition>[]
                        {
                            new Tuple<Vector, VectorPosition>(
                                vectors[0],
                                new VectorPosition(
                                    true,
                                    new Point(-3.23, 5.23, -2.73),
                                    new EulerAngle(-30, 30, 0),
                                    4.5)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[2],
                                new VectorPosition(
                                    true,
                                    new Point(3, 1, 0),
                                    new EulerAngle(0, 130, 0),
                                    3))
                        },
                        new Tuple<Angle, bool>[]{}),
                    new Step(
                        new Tuple<Vector, VectorPosition>[]
                        {
                            new Tuple<Vector, VectorPosition>(
                                vectors[2],
                                new VectorPosition(
                                    true,
                                    new Point(-1.27, 7.47, 0.59),
                                    new EulerAngle(0, 130, 0),
                                    3)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[3],
                                new VectorPosition(
                                    false,
                                    new Point(0, 1, 0),
                                    new EulerAngle(-75.3, 142.3, 0),
                                    6.7)),
                        },
                        new Tuple<Angle, bool>[]{}),
                    new Step(
                        new Tuple<Vector, VectorPosition>[]
                        {
                            new Tuple<Vector, VectorPosition>(
                                vectors[3],
                                new VectorPosition(
                                    true,
                                    new Point(0, 1, 0),
                                    new EulerAngle(-75.3, 142.3, 0),
                                    6.7)),
                        },
                        new Tuple<Angle, bool>[]{})
                });

            return visualization;
        }

        private Vizualization GetVisualizationCommutativeRule()
        {
            var vectors = new Vector[]
                {
                    new Vector(Color.blue),
                    new Vector(Color.yellow),
                    new Vector(Color.green),
                    new Vector(Color.red)
                };

            var visualization = new Vizualization(
                2,
                "Kommutativgesetz",
                vectors,
                new Step[]
                {
                    new Step(
                        new Tuple<Vector, VectorPosition>[]
                        {
                            new Tuple<Vector, VectorPosition>(
                                vectors[0],
                                new VectorPosition(
                                    true,
                                    new Point(-3.23, 5.23, -2.73),
                                    new EulerAngle(-30, 30, 0),
                                    4.5)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[1],
                                new VectorPosition(
                                    true,
                                    new Point(0, 1, 0),
                                    new EulerAngle(-45, 230, 0),
                                    6)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[2],
                                new VectorPosition(
                                    true,
                                    new Point(-1.27, 7.47, 0.59),
                                    new EulerAngle(0, 130, 0),
                                    3)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[3],
                                new VectorPosition(
                                    true,
                                    new Point(0, 1, 0),
                                    new EulerAngle(-75.3, 142.3, 0),
                                    6.7)),
                        },
                        new Tuple<Angle, bool>[]{}),
                    new Step(
                        new Tuple<Vector, VectorPosition>[]
                        {
                            new Tuple<Vector, VectorPosition>(
                                vectors[0],
                                new VectorPosition(
                                    true,
                                    new Point(-5, 5.23, -2.73),
                                    new EulerAngle(-30, 30, 0),
                                    4.5)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[2],
                                new VectorPosition(
                                    true,
                                    new Point(-1.27, 7.47, 0.59),
                                    new EulerAngle(0, 130, 0),
                                    3)),
                        },
                        new Tuple<Angle, bool>[]{}),
                    new Step(
                        new Tuple<Vector, VectorPosition>[]
                        {
                            new Tuple<Vector, VectorPosition>(
                                vectors[0],
                                new VectorPosition(
                                    true,
                                    new Point(-5, 5.23, -2.73),
                                    new EulerAngle(-30, 30, 0),
                                    4.5)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[2],
                                new VectorPosition(
                                    true,
                                    new Point(-3.23, 5.23, -2.73),
                                    new EulerAngle(0, 130, 0),
                                    3))
                        },
                        new Tuple<Angle, bool>[]{}),
                    new Step(
                        new Tuple<Vector, VectorPosition>[]
                        {
                            new Tuple<Vector, VectorPosition>(
                                vectors[0],
                                new VectorPosition(
                                    true,
                                    new Point(-0.9, 5.23, -4.71),
                                    new EulerAngle(-30, 30, 0),
                                    4.5)),
                        },
                        new Tuple<Angle, bool>[]{})
                });

            return visualization;
        }

        private Vizualization GetVisualizationSubtraction()
        {
            var vectors = new Vector[]
                {
                    new Vector(Color.green),
                    new Vector(Color.red)
                };

            var visualization = new Vizualization(
                3,
                "Vektorsubtraktion",
                vectors,
                new Step[]
                {
                    new Step(
                        new Tuple<Vector, VectorPosition>[]
                        {
                            new Tuple<Vector, VectorPosition>(
                                vectors[0],
                                new VectorPosition(
                                    true,
                                    new Point(0, 1, 0),
                                    new EulerAngle(0, 90, 0),
                                    4)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[1],
                                new VectorPosition(
                                    true,
                                    new Point(0, 1, 0),
                                    new EulerAngle(0, -90, 0),
                                    4)),
                        },
                        new Tuple<Angle, bool>[]{}),
                    new Step(
                        new Tuple<Vector, VectorPosition>[]
                        {
                            new Tuple<Vector, VectorPosition>(
                                vectors[0],
                                new VectorPosition(
                                    true,
                                    new Point(0, 1, 0),
                                    new EulerAngle(0, 90, 0),
                                    4)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[1],
                                new VectorPosition(
                                    true,
                                    new Point(4, 1, 0),
                                    new EulerAngle(0, -90, 0),
                                    4)),
                        },
                        new Tuple<Angle, bool>[]{}),
                });

            return visualization;
        }

        private Vizualization GetVisualizationCube()
        {
            var vectors = new Vector[]
                {
                    new Vector(Color.gray, false),
                    new Vector(Color.gray, false),
                    new Vector(Color.gray, false),
                    new Vector(Color.gray, false),
                    new Vector(Color.gray, false),
                    new Vector(Color.gray, false),
                    new Vector(Color.gray, false),
                    new Vector(Color.gray, false),
                    new Vector(Color.gray, false),
                    new Vector(Color.gray, false),
                    new Vector(Color.gray, false),
                    new Vector(Color.gray, false),
                    new Vector(Color.yellow),
                    new Vector(Color.green),
                    new Vector(Color.blue),
                    new Vector(Color.red)
                };

            var visualization = new Vizualization(
                4,
                "Raumdiagonale",
                vectors,
                new Step[]
                {
                    new Step(
                            new Tuple<Vector, VectorPosition>[]
                            {
                                new Tuple<Vector, VectorPosition>(
                                    vectors[0],
                                    new VectorPosition(
                                        true,
                                        new Point(-3, 1, 3),
                                        new EulerAngle(0, 180, 0),
                                        6)),
                                new Tuple<Vector, VectorPosition>(
                                    vectors[1],
                                    new VectorPosition(
                                        true,
                                        new Point(-3, 7, 3),
                                        new EulerAngle(0, 180, 0),
                                        6)),
                                new Tuple<Vector, VectorPosition>(
                                    vectors[2],
                                    new VectorPosition(
                                        true,
                                        new Point(3, 1, 3),
                                        new EulerAngle(0, 180, 0),
                                        6)),
                                new Tuple<Vector, VectorPosition>(
                                    vectors[3],
                                    new VectorPosition(
                                        true,
                                        new Point(3, 7, 3),
                                        new EulerAngle(0, 180, 0),
                                        6)),
                                new Tuple<Vector, VectorPosition>(
                                    vectors[4],
                                    new VectorPosition(
                                        true,
                                        new Point(-3, 1, 3),
                                        new EulerAngle(-90, 0, 0),
                                        6)),
                                new Tuple<Vector, VectorPosition>(
                                    vectors[5],
                                    new VectorPosition(
                                        true,
                                        new Point(-3, 1, -3),
                                        new EulerAngle(-90, 0, 0),
                                        6)),
                                new Tuple<Vector, VectorPosition>(
                                    vectors[6],
                                    new VectorPosition(
                                        true,
                                        new Point(3, 1, -3),
                                        new EulerAngle(-90, 0, 0),
                                        6)),
                                new Tuple<Vector, VectorPosition>(
                                    vectors[7],
                                    new VectorPosition(
                                        true,
                                        new Point(3, 1, 3),
                                        new EulerAngle(-90, 0, 0),
                                        6)),
                                new Tuple<Vector, VectorPosition>(
                                    vectors[8],
                                    new VectorPosition(
                                        true,
                                        new Point(-3, 1, 3),
                                        new EulerAngle(0, 90, 0),
                                        6)),
                                new Tuple<Vector, VectorPosition>(
                                    vectors[9],
                                    new VectorPosition(
                                        true,
                                        new Point(-3, 1, -3),
                                        new EulerAngle(0, 90, 0),
                                        6)),
                                new Tuple<Vector, VectorPosition>(
                                    vectors[10],
                                    new VectorPosition(
                                        true,
                                        new Point(-3, 7, 3),
                                        new EulerAngle(0, 90, 0),
                                        6)),
                                new Tuple<Vector, VectorPosition>(
                                    vectors[11],
                                    new VectorPosition(
                                        true,
                                        new Point(-3, 7, -3),
                                        new EulerAngle(0, 90, 0),
                                        6)),
                                new Tuple<Vector, VectorPosition>(
                                    vectors[12],
                                    new VectorPosition(
                                        false,
                                        new Point(-3, 1, 3),
                                        new EulerAngle(0, 180, 0),
                                        6)),
                                new Tuple<Vector, VectorPosition>(
                                    vectors[13],
                                    new VectorPosition(
                                        false,
                                        new Point(-3, 1, -3),
                                        new EulerAngle(-90, 0, 0),
                                        6)),
                                new Tuple<Vector, VectorPosition>(
                                    vectors[14],
                                    new VectorPosition(
                                        false,
                                        new Point(-3, 7, -3),
                                        new EulerAngle(0, 90, 0),
                                        6)),
                                new Tuple<Vector, VectorPosition>(
                                    vectors[15],
                                    new VectorPosition(
                                        true,
                                        new Point(-3, 1, 3),
                                        new EulerAngle(-35.26, 135, 0),
                                        10.392))
                            },
                            new Tuple<Angle, bool>[] {}),
                        new Step(
                            new Tuple<Vector, VectorPosition>[]
                            {
                                new Tuple<Vector, VectorPosition>(
                                    vectors[0],
                                    new VectorPosition(
                                        false,
                                        new Point(-3, 1, 3),
                                        new EulerAngle(0, 180, 0),
                                        6)),
                                new Tuple<Vector, VectorPosition>(
                                    vectors[5],
                                    new VectorPosition(
                                        true,
                                        new Point(-3, 1, -3),
                                        new EulerAngle(-90, 0, 0),
                                        6)),
                                new Tuple<Vector, VectorPosition>(
                                    vectors[11],
                                    new VectorPosition(
                                        true,
                                        new Point(-3, 7, -3),
                                        new EulerAngle(0, 90, 0),
                                        6)),
                                new Tuple<Vector, VectorPosition>(
                                    vectors[12],
                                    new VectorPosition(
                                        true,
                                        new Point(-3, 1, 3),
                                        new EulerAngle(0, 180, 0),
                                        6)),
                                new Tuple<Vector, VectorPosition>(
                                    vectors[13],
                                    new VectorPosition(
                                        false,
                                        new Point(-3, 1, -3),
                                        new EulerAngle(-90, 0, 0),
                                        6)),
                                new Tuple<Vector, VectorPosition>(
                                    vectors[14],
                                    new VectorPosition(
                                        false,
                                        new Point(-3, 7, -3),
                                        new EulerAngle(0, 90, 0),
                                        6)),
                            },
                            new Tuple<Angle, bool>[] {}),
                        new Step(
                            new Tuple<Vector, VectorPosition>[]
                            {
                                new Tuple<Vector, VectorPosition>(
                                    vectors[0],
                                    new VectorPosition(
                                        false,
                                        new Point(-3, 1, 3),
                                        new EulerAngle(0, 180, 0),
                                        6)),
                                new Tuple<Vector, VectorPosition>(
                                    vectors[5],
                                    new VectorPosition(
                                        false,
                                        new Point(-3, 1, -3),
                                        new EulerAngle(-90, 0, 0),
                                        6)),
                                new Tuple<Vector, VectorPosition>(
                                    vectors[11],
                                    new VectorPosition(
                                        true,
                                        new Point(-3, 7, -3),
                                        new EulerAngle(0, 90, 0),
                                        6)),
                                new Tuple<Vector, VectorPosition>(
                                    vectors[12],
                                    new VectorPosition(
                                        true,
                                        new Point(-3, 1, 3),
                                        new EulerAngle(0, 180, 0),
                                        6)),
                                new Tuple<Vector, VectorPosition>(
                                    vectors[13],
                                    new VectorPosition(
                                        true,
                                        new Point(-3, 1, -3),
                                        new EulerAngle(-90, 0, 0),
                                        6)),
                                new Tuple<Vector, VectorPosition>(
                                    vectors[14],
                                    new VectorPosition(
                                        false,
                                        new Point(-3, 7, -3),
                                        new EulerAngle(0, 90, 0),
                                        6)),
                            },
                            new Tuple<Angle, bool>[] {}),
                        new Step(
                            new Tuple<Vector, VectorPosition>[]
                            {
                                new Tuple<Vector, VectorPosition>(
                                    vectors[0],
                                    new VectorPosition(
                                        false,
                                        new Point(-3, 1, 3),
                                        new EulerAngle(0, 180, 0),
                                        6)),
                                new Tuple<Vector, VectorPosition>(
                                    vectors[5],
                                    new VectorPosition(
                                        false,
                                        new Point(-3, 1, -3),
                                        new EulerAngle(-90, 0, 0),
                                        6)),
                                new Tuple<Vector, VectorPosition>(
                                    vectors[11],
                                    new VectorPosition(
                                        false,
                                        new Point(-3, 7, -3),
                                        new EulerAngle(0, 90, 0),
                                        6)),
                                new Tuple<Vector, VectorPosition>(
                                    vectors[12],
                                    new VectorPosition(
                                        true,
                                        new Point(-3, 1, 3),
                                        new EulerAngle(0, 180, 0),
                                        6)),
                                new Tuple<Vector, VectorPosition>(
                                    vectors[13],
                                    new VectorPosition(
                                        true,
                                        new Point(-3, 1, -3),
                                        new EulerAngle(-90, 0, 0),
                                        6)),
                                new Tuple<Vector, VectorPosition>(
                                    vectors[14],
                                    new VectorPosition(
                                        true,
                                        new Point(-3, 7, -3),
                                        new EulerAngle(0, 90, 0),
                                        6)),
                            },
                            new Tuple<Angle, bool>[] {})
                    });

            return visualization;
        }

        private Vizualization GetVisualizationScalarProduct()
        {
            var vectors = new Vector[]
                {
                    new Vector(Color.red), // Vector 1
                    new Vector(Color.blue), // Vector 2
                    new Vector(Color.green), // Vector 2 Component 1
                    new Vector(Color.green), // Vector 2 Component 2
                    new Vector(Color.green), // Vector 2 Component 3
                    new Vector(Color.gray, false), // border 1
                    new Vector(Color.gray, false), // border 2
                    new Vector(Color.gray, false), // border filler 1
                    new Vector(Color.gray, false), // border filler 2
                    new Vector(Color.gray, false), // border filler 3
                };

            var visualization = new Vizualization(
                5,
                "Skalarprodukt",
                vectors,
                new Step[]
                {
                    new Step(
                        new Tuple<Vector, VectorPosition>[]
                        {
                            new Tuple<Vector, VectorPosition>(
                                vectors[0],
                                new VectorPosition(
                                    true,
                                    new Point(-3, 1, -2),
                                    new EulerAngle(0, 0, 0),
                                    4)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[1],
                                new VectorPosition(
                                    true,
                                    new Point(3, 1, -3),
                                    new EulerAngle(-22.59, -33.69, 0),
                                    7.81)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[2],
                                new VectorPosition(
                                    false,
                                    new Point(3, 1, -3),
                                    new EulerAngle(0, -90, 0),
                                    4)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[3],
                                new VectorPosition(
                                    false,
                                    new Point(3, 1, -3),
                                    new EulerAngle(-90, 0, 0),
                                    3)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[4],
                                new VectorPosition(
                                    false,
                                    new Point(3, 1, -3),
                                    new EulerAngle(0, 0, 0),
                                    6)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[5],
                                new VectorPosition(
                                    false,
                                    new Point(3, 1, -2),
                                    new EulerAngle(-90, 0, 0),
                                    4)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[6],
                                new VectorPosition(
                                    false,
                                    new Point(-3, 5, -2),
                                    new EulerAngle(0, 90, 0),
                                    6)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[7],
                                new VectorPosition(
                                    false,
                                    new Point(-3, 3, -2),
                                    new EulerAngle(-33.69, 90, 0),
                                    3.61)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[8],
                                new VectorPosition(
                                    false,
                                    new Point(-3, 1, -2),
                                    new EulerAngle(-33.69, 90, 0),
                                    7.21)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[9],
                                new VectorPosition(
                                    false,
                                    new Point(0, 1, -2),
                                    new EulerAngle(-33.69, 90, 0),
                                    3.61)),
                        },
                        new Tuple<Angle, bool>[]{}),
                    new Step(
                        new Tuple<Vector, VectorPosition>[]
                        {
                            new Tuple<Vector, VectorPosition>(
                                vectors[1],
                                new VectorPosition(
                                    true,
                                    new Point(3, 1, -3),
                                    new EulerAngle(-22.59, -33.69, 0),
                                    7.81)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[2],
                                new VectorPosition(
                                    true,
                                    new Point(3, 1, -3),
                                    new EulerAngle(0, -90, 0),
                                    4)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[3],
                                new VectorPosition(
                                    true,
                                    new Point(3, 1, -3),
                                    new EulerAngle(-90, 0, 0),
                                    3)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[4],
                                new VectorPosition(
                                    true,
                                    new Point(3, 1, -3),
                                    new EulerAngle(0, 0, 0),
                                    6)),
                        },
                        new Tuple<Angle, bool>[]{}),
                    new Step(
                        new Tuple<Vector, VectorPosition>[]
                        {
                            new Tuple<Vector, VectorPosition>(
                                vectors[0],
                                new VectorPosition(
                                    true,
                                    new Point(-3, 1, -2),
                                    new EulerAngle(0, 0, 0),
                                    4)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[1],
                                new VectorPosition(
                                    false,
                                    new Point(3, 1, -3),
                                    new EulerAngle(-22.59, -33.69, 0),
                                    7.81)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[2],
                                new VectorPosition(
                                    false,
                                    new Point(3, 1, -3),
                                    new EulerAngle(0, -90, 0),
                                    4)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[3],
                                new VectorPosition(
                                    false,
                                    new Point(3, 1, -3),
                                    new EulerAngle(-90, 0, 0),
                                    3)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[4],
                                new VectorPosition(
                                    true,
                                    new Point(3, 1, -3),
                                    new EulerAngle(0, 0, 0),
                                    6)),
                        },
                        new Tuple<Angle, bool>[]{}),
                    new Step(
                        new Tuple<Vector, VectorPosition>[]
                        {
                            new Tuple<Vector, VectorPosition>(
                                vectors[0],
                                new VectorPosition(
                                    true,
                                    new Point(-3, 1, -2),
                                    new EulerAngle(-90, 0, 0),
                                    4)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[4],
                                new VectorPosition(
                                    true,
                                    new Point(-3, 1, -2),
                                    new EulerAngle(0, 90, 0),
                                    6)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[5],
                                new VectorPosition(
                                    false,
                                    new Point(3, 1, -2),
                                    new EulerAngle(-90, 0, 0),
                                    4)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[6],
                                new VectorPosition(
                                    false,
                                    new Point(-3, 5, -2),
                                    new EulerAngle(0, 90, 0),
                                    6)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[7],
                                new VectorPosition(
                                    false,
                                    new Point(-3, 3, -2),
                                    new EulerAngle(-33.69, 90, 0),
                                    3.61)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[8],
                                new VectorPosition(
                                    false,
                                    new Point(-3, 1, -2),
                                    new EulerAngle(-33.69, 90, 0),
                                    7.21)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[9],
                                new VectorPosition(
                                    false,
                                    new Point(0, 1, -2),
                                    new EulerAngle(-33.69, 90, 0),
                                    3.61)),
                        },
                        new Tuple<Angle, bool>[]{}),
                    new Step(
                        new Tuple<Vector, VectorPosition>[]
                        {
                            new Tuple<Vector, VectorPosition>(
                                vectors[5],
                                new VectorPosition(
                                    true,
                                    new Point(3, 1, -2),
                                    new EulerAngle(-90, 0, 0),
                                    4)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[6],
                                new VectorPosition(
                                    true,
                                    new Point(-3, 5, -2),
                                    new EulerAngle(0, 90, 0),
                                    6)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[7],
                                new VectorPosition(
                                    true,
                                    new Point(-3, 3, -2),
                                    new EulerAngle(-33.69, 90, 0),
                                    3.61)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[8],
                                new VectorPosition(
                                    true,
                                    new Point(-3, 1, -2),
                                    new EulerAngle(-33.69, 90, 0),
                                    7.21)),
                            new Tuple<Vector, VectorPosition>(
                                vectors[9],
                                new VectorPosition(
                                    true,
                                    new Point(0, 1, -2),
                                    new EulerAngle(-33.69, 90, 0),
                                    3.61)),
                        },
                        new Tuple<Angle, bool>[]{}),
                });

            return visualization;
        }
    }
}
